import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './LicenseApplicationForm.css';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';
import ModalNotification from '../../Components/ModalNotification/ModalNotification';
import { submitLicenseApplication } from '../../api/common'; 

const LicenseApplicationForm = () => {
  const [form, setForm] = useState({
    idType: 'NIC',
    idNumber: '',
    surname: '',
    otherNames: '',
    printedName: '',
    heightFeet: '',
    heightInches: '',
    bloodGroup: '',
    organDonor: 'yes',
    address: '',
    phoneNumber: '',
    secretariat: '',
    restrictions: [],
    birthCertificate: null,
    medicalCertificate: null,
  });

  const [errors, setErrors] = useState({});
  const [showModal, setShowModal] = useState(false);
  const [modalContent, setModalContent] = useState({ title: '', message: '' });
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value, type, checked, files } = e.target;

    if (type === 'checkbox') {
      setForm((prev) => {
        const newRestrictions = checked
          ? [...prev.restrictions, value]
          : prev.restrictions.filter((r) => r !== value);
        return { ...prev, restrictions: newRestrictions };
      });
    } else if (type === 'file') {
      setForm({ ...form, [name]: files[0] });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const validate = () => {
    let newErrors = {};

    if (!form.idNumber.trim()) newErrors.idNumber = 'ID/Passport Number is required';
    if (!form.surname.trim()) newErrors.surname = 'Surname is required';
    if (!form.printedName.trim()) newErrors.printedName = 'Printed Name is required';
    if (!form.address.trim()) newErrors.address = 'Address is required';
    if (!form.phoneNumber.trim()) newErrors.phoneNumber = 'Phone Number is required';
    else if (!/^[0-9]{10}$/.test(form.phoneNumber))
      newErrors.phoneNumber = 'Phone number must be 10 digits';
    if (!form.secretariat.trim()) newErrors.secretariat = 'Divisional Secretariat is required';

    if (!form.birthCertificate)
      newErrors.birthCertificate = 'Birth Certificate (PDF) is required';
    else if (!form.birthCertificate.name.endsWith('.pdf'))
      newErrors.birthCertificate = 'Birth Certificate must be a PDF file';

    if (!form.medicalCertificate)
      newErrors.medicalCertificate = 'Medical Certificate (PDF) is required';
    else if (!form.medicalCertificate.name.endsWith('.pdf'))
      newErrors.medicalCertificate = 'Medical Certificate must be a PDF file';

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
  e.preventDefault();

  if (!validate()) return;

  const formData = new FormData();
  formData.append('IdType', form.idType);
  formData.append('IdNumber', form.idNumber);
  formData.append('Surname', form.surname);
  formData.append('OtherNames', form.otherNames);
  formData.append('PrintedName', form.printedName);
  formData.append('HeightFeet', form.heightFeet);
  formData.append('HeightInches', form.heightInches);
  formData.append('BloodGroup', form.bloodGroup);
  formData.append('OrganDonor', form.organDonor);
  formData.append('Address', form.address);
  formData.append('PhoneNumber', form.phoneNumber);
  formData.append('Secretariat', form.secretariat);
  form.restrictions.forEach((r) => formData.append('Restrictions', r));
  formData.append('BirthCertificate', form.birthCertificate);
  formData.append('MedicalCertificate', form.medicalCertificate);

  // ✅ Add logged-in userId from localStorage
  const userId = localStorage.getItem('userId');
  if (userId) {
    formData.append('UserId', userId);
  }

  try {
    const result = await submitLicenseApplication(formData);

    const formCopy = { ...form };
    formCopy.birthCertificate = form.birthCertificate?.name || '';
    formCopy.medicalCertificate = form.medicalCertificate?.name || '';
    localStorage.setItem('licenseData', JSON.stringify(formCopy));

    setModalContent({
      title: 'Application Submitted',
      message: result.message || 'Your license application has been submitted successfully!',
    });
    setShowModal(true);
  } catch (error) {
    console.error('Submission failed:', error);

    setModalContent({
      title: 'Submission Failed',
      message: error.response?.data?.message || 'There was an error submitting your form. Please try again.',
    });
    setShowModal(true);
  }
};


  const handleModalClose = () => {
    setShowModal(false);
    if (modalContent.title === 'Application Submitted') {
      navigate('/application-summary');
    }
  };

  return (
    <>
      <Navbar />
      <form className="license-form" onSubmit={handleSubmit}>
        <h2>A. Personal Details</h2>

        <div className="form-row">
          <div className="form-group">
            <label>ID Type</label>
            <select name="idType" value={form.idType} onChange={handleChange}>
              <option value="NIC">NIC</option>
              <option value="Passport">Passport</option>
            </select>
          </div>
          <div className="form-group">
            <label>ID/Passport Number</label>
            <input type="text" name="idNumber" value={form.idNumber} onChange={handleChange} />
            {errors.idNumber && <p className="error">{errors.idNumber}</p>}
          </div>
        </div>

        <div className="form-row">
          <div className="form-group">
            <label>Surname</label>
            <input type="text" name="surname" value={form.surname} onChange={handleChange} />
            {errors.surname && <p className="error">{errors.surname}</p>}
          </div>
          <div className="form-group">
            <label>Other Names</label>
            <input type="text" name="otherNames" value={form.otherNames} onChange={handleChange} />
          </div>
        </div>

        <div className="form-group full-width">
          <label>Name to be printed on the card</label>
          <input type="text" name="printedName" value={form.printedName} onChange={handleChange} />
          {errors.printedName && <p className="error">{errors.printedName}</p>}
        </div>

        <h2>B. Additional Personal Details</h2>
        <div className="form-row">
          <div className="form-group">
            <label>Height (Feet)</label>
            <input type="number" name="heightFeet" value={form.heightFeet} onChange={handleChange} />
          </div>
          <div className="form-group">
            <label>Height (Inches)</label>
            <input type="number" name="heightInches" value={form.heightInches} onChange={handleChange} />
          </div>
        </div>

        <div className="form-row">
          <div className="form-group">
            <label>Blood Group</label>
            <input type="text" name="bloodGroup" value={form.bloodGroup} onChange={handleChange} />
          </div>
          <div className="form-group">
            <label>Organ Donor</label>
            <div className="radio-group">
              <label>
                <input
                  type="radio"
                  name="organDonor"
                  value="yes"
                  checked={form.organDonor === 'yes'}
                  onChange={handleChange}
                />
                Yes
              </label>
              <label>
                <input
                  type="radio"
                  name="organDonor"
                  value="no"
                  checked={form.organDonor === 'no'}
                  onChange={handleChange}
                />
                No
              </label>
            </div>
          </div>
        </div>

        <div className="form-group full-width">
          <label>Permanent Address</label>
          <textarea name="address" value={form.address} onChange={handleChange}></textarea>
          {errors.address && <p className="error">{errors.address}</p>}
        </div>

        <div className="form-row">
          <div className="form-group">
            <label>Phone Number</label>
            <input type="tel" name="phoneNumber" value={form.phoneNumber} onChange={handleChange} />
            {errors.phoneNumber && <p className="error">{errors.phoneNumber}</p>}
          </div>
          <div className="form-group">
            <label>Divisional Secretariat</label>
            <input type="text" name="secretariat" value={form.secretariat} onChange={handleChange} />
            {errors.secretariat && <p className="error">{errors.secretariat}</p>}
          </div>
        </div>

        <div className="form-group full-width">
          <label>Driver Restrictions</label>
          <div className="checkbox-group">
            <label>
              <input type="checkbox" name="restrictions" value="None" onChange={handleChange} />
              None
            </label>
            <label>
              <input type="checkbox" name="restrictions" value="Corrective Lenses" onChange={handleChange} />
              Corrective Lenses
            </label>
            <label>
              <input type="checkbox" name="restrictions" value="Artificial Limb" onChange={handleChange} />
              Artificial Limb
            </label>
          </div>
        </div>

        <div className="form-group full-width">
          <label>Upload Birth Certificate (PDF)</label>
          <input type="file" name="birthCertificate" accept=".pdf" onChange={handleChange} />
          {errors.birthCertificate && <p className="error">{errors.birthCertificate}</p>}
        </div>

        <div className="form-group full-width">
          <label>Upload Medical Certificate (PDF)</label>
          <input type="file" name="medicalCertificate" accept=".pdf" onChange={handleChange} />
          {errors.medicalCertificate && <p className="error">{errors.medicalCertificate}</p>}
        </div>

        <div className="form-group full-width">
          <button type="submit" className="submit-btn">Submit Application</button>
        </div>
      </form>

      {showModal && (
        <ModalNotification
          title={modalContent.title}
          message={modalContent.message}
          buttonText="OK"
          onClose={handleModalClose}
        />
      )}

      <Footer />
    </>
  );
};

export default LicenseApplicationForm;

