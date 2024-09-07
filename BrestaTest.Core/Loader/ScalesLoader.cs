using BrestaTest.Core.Models.Abstract;
using BrestaTest.Core.Models.Boards;
using BrestaTest.Core.Models.Scales;
using BrestaTest.Core.Parser;
using BrestaTest.Core.Parser.Exceptions;

namespace BrestaTest.Core.Loader
{
    public static class ScalesLoader
    {
        /// <summary>
        /// Загрузка весов из директорий
        /// </summary>
        /// <returns>Словарь модель весов - ассоциированные с ними элеметы борды </returns>
        public static Dictionary<ScalesMV4TD, IEnumerable<ScalesBoardElement>> LoadScales(string scalesDirectory, string boardsDirectory)
        {
            if (!Directory.Exists(scalesDirectory))
            {
                throw new DirectoryNotFoundException($"Directory with scales cfg files doesn't exist : {scalesDirectory}");
            }
            if (!Directory.Exists(boardsDirectory))
            {
                throw new DirectoryNotFoundException($"Directory with boards cfg files doesn't exist : {boardsDirectory}");
            }
            var scalesFileNames = new DirectoryInfo(scalesDirectory).EnumerateFiles().Select(x => x.FullName);
            var boardsFileNames = new DirectoryInfo(boardsDirectory).EnumerateFiles().Select(x => x.FullName);
            var scalesModels = new Dictionary<string, ScalesMV4TD>();
            var scaleBoardModels = new Dictionary<string, List<ScalesBoardElement>>();
            foreach (var sc in scalesFileNames)
            {
                var fInfo = new FileInfo(sc);
                var fileContent = File.ReadAllText(sc);
                BrestaCfgParser.ParseCfg(fInfo.FullName, fileContent, Models.Enums.ModelType.ScalesMV4TD, out List<BaseEntity> models);
                if (models.Count != 1) throw new InvalidBrestaFormatException();
                scalesModels.Add(fInfo.Name, models.First() as ScalesMV4TD);
            }
            foreach (var brd in boardsFileNames)
            {
                var fInfo = new FileInfo(brd);
                var fileContent = File.ReadAllText(brd);
                BrestaCfgParser.ParseCfg(fInfo.FullName, fileContent, Models.Enums.ModelType.ScaleBoardElement, out List<BaseEntity> models);
                scaleBoardModels.Add(fInfo.Name, models.Select(x=>x as ScalesBoardElement).ToList());
            }
            var result = new Dictionary<ScalesMV4TD, IEnumerable<ScalesBoardElement>>();
            foreach(var sc in scalesModels)
            {
                if (scaleBoardModels.TryGetValue(sc.Key, out List<ScalesBoardElement> boards))
                {
                    result.Add(sc.Value, boards);
                }
                else
                {
                    result.Add(sc.Value, []);
                }
            }
            return result;
        }
    }
}
