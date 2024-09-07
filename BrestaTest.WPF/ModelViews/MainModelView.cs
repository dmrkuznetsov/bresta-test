using BrestaTest.WPF.DataAccess;
using BrestaTest.WPF.ModelViews.Abstract;
using BrestaTest.WPF.ModelViews.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace BrestaTest.WPF.ModelViews
{
    internal class MainModelView : ObservableObject
    {
        #region Поля-свойства
        private bool _longProcessIsActive = false;
        public bool LongProcessActive 
        {
            get { return _longProcessIsActive; }
            set { _longProcessIsActive = value; RaisePropertyChanged(); RaisePropertyChanged(nameof(LongProcessIsNotActive)); }
        }
        public bool LongProcessIsNotActive 
        {
            get { return !_longProcessIsActive; }
        }
        public ObservableCollection<ScalesModelView> Scales { get; } = new ObservableCollection<ScalesModelView>();

        private string _scalesDirectory = @"C:\Users\Dmitry\Documents\Bresta\scales";
		public string ScalesDirectory 
		{
			get { return _scalesDirectory; }
			set { _scalesDirectory = value; RaisePropertyChanged(); }
		}
		private string _boardsDirectory = @"C:\Users\Dmitry\Documents\Bresta\boards";
		public string BoardsDirectory 
		{
			get { return _boardsDirectory; }
			set { _boardsDirectory = value; RaisePropertyChanged(); }
		}
        #endregion

        #region Команды

        #region Загрузить модели весов
        public ICommand LoadScalesCmd { get; }
        public async void OnLoadScales(object parameter)
        {
            try
            {
                LongProcessActive = true;
                Scales.Clear();
                await Task.Run(() =>
                {
                    var vms = CfgLoader.LoadScales(ScalesDirectory, BoardsDirectory);
                    foreach(var v in vms)
                    {
                        Scales.Add(v);
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LongProcessActive = false;
            }
        }
        public bool CanLoadScales(object parameter) => true;
        #endregion

        #region Выбор пути до папки с boards
        public ICommand SelectBoardsDirectoryCmd { get; }
        public void OnSelectBoardsDirectory(object parameter)
        {
            var folder = "";
            var folderDialog = new OpenFolderDialog();
            if (folderDialog.ShowDialog() == true)
            {
                folder = folderDialog.FolderName;
            }
            if (!Directory.Exists(folder)) return;
            BoardsDirectory = folder;
        }
        public bool CanSelectBoardsDirectory(object parameter) => true;
        #endregion

        #region Выбор пути до папки с scales 
        public ICommand SelectScalesDirCmd { get; }
        public void OnSelectScalesDir(object parameter)
        {
            var folder = "";
            var folderDialog = new OpenFolderDialog();
            if (folderDialog.ShowDialog() == true)
            {
                folder = folderDialog.FolderName;
            }
            if (!Directory.Exists(folder)) return;
            BoardsDirectory = folder;
        }
        public bool CanSelectScalesDir(object parameter) => true;

        #endregion

        #endregion

        public MainModelView()
        {
            SelectBoardsDirectoryCmd = new RelayCommand(OnSelectBoardsDirectory, CanSelectBoardsDirectory);
            SelectScalesDirCmd = new RelayCommand(OnSelectBoardsDirectory, CanSelectBoardsDirectory);
            LoadScalesCmd = new RelayCommand(OnLoadScales, CanLoadScales);
        }
    }
}
