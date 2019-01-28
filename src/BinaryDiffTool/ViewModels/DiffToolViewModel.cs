using BinaryDiffTool.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryDiffTool.ViewModels
{
    public class DiffToolViewModel : ViewModelBase
    {
        #region properties

        private string fileName1;

        public string FileName1
        {
            get
            {
                return fileName1;
            }
            set
            {
                fileName1 = value;
                OnPropertyChanged();
            }
        }

        private string fileName2;

        public string FileName2
        {
            get
            {
                return fileName2;
            }
            set
            {
                fileName2 = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LineDiff> diffs;

        public ObservableCollection<LineDiff> Diffs
        {
            get { return diffs; }
            set
            {
                diffs = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region public methods

        private ICommand openFile1;

        public ICommand OpenFile1
        {
            get
            {
                return openFile1 ?? (openFile1 = new RelayCommand(
                    x =>
                    {
                        FileName1 = GetFileName();
                        if(fileName2 != null)
                        {
                            DiffFiles();
                        }
                    }));
            }
        }

        private ICommand openFile2;

        public ICommand OpenFile2
        {
            get
            {
                return openFile2 ?? (openFile2 = new RelayCommand(
                    x =>
                    {
                        FileName2 = GetFileName();
                        if(fileName1 != null)
                        {
                            DiffFiles();
                        }
                    }));
            }
        }

        private ICommand refreshDiff;

        public ICommand RefreshDiff
        {
            get
            {
                return refreshDiff ?? (refreshDiff = new RelayCommand(
                    x =>
                    {
                        DiffFiles();
                    }));
            }
        }

        #endregion

        #region private methods

        private string GetFileName()
        {
            string fileName = "";
            OpenFileDialog ofd = new OpenFileDialog();

            bool? result = ofd.ShowDialog();
            if(result == true)
            {
                fileName = ofd.FileName;
            }

            return fileName;
        }

        private void DiffFiles()
        {
            Diffs = new ObservableCollection<LineDiff>(BinaryFileComparer.GetDifferences(fileName1, fileName2));
        }

        #endregion

        public DiffToolViewModel()
        {
            Diffs = new ObservableCollection<LineDiff>();
        }


    }
}
