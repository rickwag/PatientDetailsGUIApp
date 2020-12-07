using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PatientDetails.Models
{
    public class PatientService
    {
        #region fields
        private List<PatientData> patientsData;
        private List<Patient> patients;
        private string saveFileName = "patientsData.sav";
        private BinaryFormatter binaryFormatter;
        #endregion

        #region methods
        public PatientService()
        {
            patientsData = new List<PatientData>();
            patients = new List<Patient>();
            binaryFormatter = new BinaryFormatter();

            LoadPatientsDataFromFile();
            PopulatePatients();
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public void PopulatePatients()
        {
            foreach (var patientData in patientsData)
            {
                patients.Add(new Patient(patientData));
            }
        }
        public void PopulatePatientsData(IList<Patient> patients)
        {
            patientsData.Clear();

            foreach (var patient in patients)
            {
                patientsData.Add(patient.GetData());
            }
        }
        public void SavePatientsDataToFile()
        {
            using (FileStream fstream = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                binaryFormatter.Serialize(fstream, patientsData);
            }
        }
        public void LoadPatientsDataFromFile()
        {
            try
            {
                FileStream fileStream = new FileStream(saveFileName, FileMode.Open, FileAccess.Read);
                patientsData = binaryFormatter.Deserialize(fileStream) as List<PatientData>;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString(), "exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SaveData(IList<Patient> _patients)
        {
            PopulatePatientsData(_patients);
            SavePatientsDataToFile();
        }
        #endregion
    }
}
