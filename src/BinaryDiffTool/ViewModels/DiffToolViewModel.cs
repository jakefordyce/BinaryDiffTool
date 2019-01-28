using System;
using System.Collections.Generic;
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

                    }));
            }
        }

        #endregion

        public DiffToolViewModel()
        {

        }


    }
}
