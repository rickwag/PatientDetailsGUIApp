using System.Collections.Generic;
using System.Collections.ObjectModel;
using PatientDetails.Models;
using PatientDetails.Views;
using PatientDetails.Commands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace PatientDetails.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        #region fields
        private ObservableCollection<Patient> patients;
        private PatientService patientService;
        private HomePage homePage;
        private DetailsPage detailsPage;
        private Patient currentPatient;
        private int selectedIndex;
        private int initialPatientsCount = 0;
        private RelayCommand goToHomeCommand;
        private RelayCommand addPatientCommand;
        private RelayCommand deleteSelectedPatientCommand;
        private RelayCommand viewSelectedCommand;
        private RelayCommand exitCommand;
        private RelayCommand saveDataCommand;
        private RelayCommand openImageCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region properties
        public ObservableCollection<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
        public Patient CurrentPatient
        {
            get { return currentPatient; }
            set
            { 
                currentPatient = value;

                OnPropertyChanged("CurrentPatient");
            }
        }
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            { 
                selectedIndex = value; 
            }
        }
        public RelayCommand GoToHomeCommand
        {
            get { return goToHomeCommand; }
        }
        public RelayCommand AddPatientCommand
        {
            get { return addPatientCommand; }
        }
        public RelayCommand DeleteSelectedPatientCommand
        {
            get { return deleteSelectedPatientCommand; }
        }
        public RelayCommand ViewSelectedCommand
        {
            get { return viewSelectedCommand; }
        }
        public RelayCommand ExitCommand
        {
            get { return exitCommand; }
        }
        public RelayCommand SaveDataCommand
        {
            get { return saveDataCommand; }
        }
        public RelayCommand OpenImageCommand
        {
            get { return openImageCommand; }
        }
        #endregion

        #region methods
        public PatientViewModel()
        {
            InitialiseCommands();

            patientService = new PatientService();
            patients = new ObservableCollection<Patient>();

            PopulatePatients();

            homePage = new HomePage();
            detailsPage = new DetailsPage();

            homePage.DataContext = this;
            detailsPage.DataContext = this;

            SwitchToHomePage();
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void InitialiseCommands()
        {
            goToHomeCommand = new RelayCommand(SwitchToHomePage);
            addPatientCommand = new RelayCommand(AddPatient);
            deleteSelectedPatientCommand = new RelayCommand(DeleteSelectedPatient);
            viewSelectedCommand = new RelayCommand(ViewSelectedPatient);
            exitCommand = new RelayCommand(ExitApplication);
            saveDataCommand = new RelayCommand(SaveData);
            openImageCommand = new RelayCommand(LoadImage);
        }
        public void PopulatePatients()
        {
            foreach (var patient in patientService.GetPatients())
            {
                Patients.Add(patient);
            }

            initialPatientsCount = patients.Count;
        }

        public void SwitchToDetailsPage(Patient selectedPatient)
        {
            CurrentPatient = selectedPatient;
            App.Current.MainWindow.Content = detailsPage;
        }
        public void SwitchToHomePage()
        {
            App.Current.MainWindow.Content = homePage;
        }

        public void AddPatient()
        {
            Patient newPatient = new Patient()
            {
                FirstName = "patient",
                LastName = "0",
                MaritalStatus = "Married to 0",
                PhoneNumber = "00000000",
                EmailAddress = $"patient@gmail.com",
                PhysicalAddress = $"patient's Place",
                Treatment = $"Given medicine"
            };

            patients.Insert(0, newPatient);
        }
        public void DeleteSelectedPatient()
        {
            if (SelectedIndex != -1)
                patients.RemoveAt(SelectedIndex);
            else
                MessageBox.Show("No Patient Selected To Delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ViewSelectedPatient()
        {
            if (SelectedIndex != -1)
                SwitchToDetailsPage(patients[SelectedIndex]);
            else
                MessageBox.Show("Sorry, Select a Patient to View", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ExitApplication()
        {
            if (HasPatientsChanged())
            {
                var mesoResult = MessageBox.Show("Do you want to save the changes?", "save data", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mesoResult == MessageBoxResult.Yes)
                {
                    SaveData();
                }
            }

            App.Current.MainWindow.Close();
        }
        public void SaveData()
        {
            patientService.SaveData((IList<Patient>)patients);
        }
        public void LoadImage()
        {
            //load image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "image(*.png, *.jpg) | *.png; *.jpg";
            openFileDialog.ShowDialog();

            string imagePath = openFileDialog.FileName;
            if (imagePath != string.Empty)
            {
                CurrentPatient.ProfilePicture = imagePath;
                CurrentPatient.ProfilePictureStretch = Stretch.Uniform;
            }
        }

        public bool HasPatientsChanged()
        {
            return initialPatientsCount == patients.Count ? false : true;
        }
        #endregion
    }
}
