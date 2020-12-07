using System;

namespace PatientDetails.Models
{
    [Serializable]
    public class PatientData
    {
        #region properties
        public string ProfilePicture
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string DateOfBirth
        {
            get; set;
        }
        public string MaritalStatus
        {
            get; set;
        }
        public string PhoneNumber
        {
            get; set;
        }
        public string EmailAddress
        {
            get; set;
        }
        public string PhysicalAddress
        {
            get; set;
        }
        public string DateOfTreatment
        {
            get; set;
        }
        public string Treatment
        {
            get; set;
        }
        #endregion
    }
}
