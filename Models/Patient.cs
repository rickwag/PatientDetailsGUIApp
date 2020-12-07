using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace PatientDetails.Models
{
    public class Patient : INotifyPropertyChanged
    {
        #region fields
        //profile picture
        private string profilePicture = null;
        private string firstName;
        private string lastName;
        private string dateOfBirth = "12/25/1963";
        private string maritalStatus;
        private string phoneNumber;
        private string emailAddress;
        private string physicalAddress;
        private string dateOfTreatment = DateTime.Today.ToString();
        private string treatment;
        private Stretch profilePictureStretch;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region properties
        public string ProfilePicture 
        {
            get { return profilePicture; }
            set
            { 
                profilePicture = value;

                OnPropertyChanged("ProfilePicture");
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;

                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string PhysicalAddress
        {
            get { return physicalAddress; }
            set { physicalAddress = value; }
        }
        public string DateOfTreatment
        {
            get { return dateOfTreatment; }
            set
            { 
                dateOfTreatment = value;

                OnPropertyChanged("DateOfTreatment");
            }
        }
        public string Treatment
        {
            get { return treatment; }
            set { treatment = value; }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public Stretch ProfilePictureStretch
        {
            set
            { 
                profilePictureStretch = value;

                OnPropertyChanged("ProfilePictureStretch");
            }
            get { return profilePictureStretch; }
        }
        #endregion

        #region methods
        public Patient()
        {
            OnCreation();
        }
        public Patient(PatientData patientData)
        {
            OnCreation();
            SetData(patientData);
        }

        public void OnCreation()
        {
            if (string.IsNullOrEmpty(ProfilePicture))
                ProfilePictureStretch = Stretch.Uniform;
        }
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public PatientData GetData()
        {
            return new PatientData()
            {
                ProfilePicture = this.ProfilePicture,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                MaritalStatus = this.MaritalStatus,
                PhoneNumber = this.PhoneNumber,
                EmailAddress = this.EmailAddress,
                PhysicalAddress = this.PhysicalAddress,
                DateOfTreatment = this.DateOfTreatment,
                Treatment = this.Treatment
            };
        }
        public void SetData(PatientData patientData)
        {
            ProfilePicture = patientData.ProfilePicture;
            FirstName = patientData.FirstName;
            LastName = patientData.LastName;
            DateOfBirth = patientData.DateOfBirth;
            MaritalStatus = patientData.MaritalStatus;
            PhoneNumber = patientData.PhoneNumber;
            PhysicalAddress = patientData.PhysicalAddress;
            EmailAddress = patientData.EmailAddress;
            DateOfTreatment = patientData.DateOfTreatment;
            Treatment = patientData.Treatment;
        }
        #endregion
    }
}
