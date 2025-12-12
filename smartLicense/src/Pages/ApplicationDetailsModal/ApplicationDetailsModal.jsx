// Components/ApplicationDetailsModal/ApplicationDetailsModal.jsx
import React, { useState, useEffect } from 'react';
import './ApplicationDetailsModal.css';
import axios from 'axios';

const ApplicationDetailsModal = ({ onClose, applicationId }) => {
  const [formData, setFormData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [viewingDocument, setViewingDocument] = useState(null);

  useEffect(() => {
    const fetchApplicationData = async () => {
      try {
        if (applicationId) {
          // Fetch from API
          const response = await axios.get(`https://localhost:7077/api/LicenseApplication/user/${applicationId}`);
          if (response.data && response.data.length > 0) {
            setFormData(response.data[0]);
          }
        } else {
          // Fallback to localStorage
          const localData = JSON.parse(localStorage.getItem('licenseData')) || {};
          setFormData(localData);
        }
        setLoading(false);
      } catch (err) {
        console.error('Error fetching application data:', err);
        setError('Failed to load application data');
        setLoading(false);
      }
    };

    fetchApplicationData();
  }, [applicationId]);

  const handleViewDocument = (docPath, docName) => {
    if (docPath && docPath !== 'Not Uploaded') {
      // Show in modal instead of new tab
      const fullPath = `https://localhost:7077/api/LicenseApplication/view/${docPath}`;
      setViewingDocument({ path: fullPath, name: docName });
    }
  };

  const handleDownloadDocument = (docPath, docName) => {
    if (docPath && docPath !== 'Not Uploaded') {
      // Use the download endpoint
      const fullPath = `https://localhost:7077/api/LicenseApplication/download/${docPath}`;
      const link = document.createElement('a');
      link.href = fullPath;
      link.download = docName;
      link.target = '_blank';
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    }
  };

  const renderDocumentActions = (docPath, docName) => {
    const hasDoc = docPath && docPath !== 'Not Uploaded';
    
    return (
      <div className="document-actions">
        {hasDoc ? (
          <>
            <button 
              className="doc-button view-button"
              onClick={() => handleViewDocument(docPath, docName)}
            >
              👁️ View
            </button>
            <button 
              className="doc-button download-button"
              onClick={() => handleDownloadDocument(docPath, docName)}
            >
              📥 Download
            </button>
          </>
        ) : (
          <span className="no-document">Not Uploaded</span>
        )}
      </div>
    );
  };

  const renderCertificatePreview = (docPath, docName) => {
    const hasDoc = docPath && docPath !== 'Not Uploaded';
    
    if (!hasDoc) {
      return (
        <div className="no-preview">
          <div className="no-preview-icon">📄</div>
          <div>No document uploaded</div>
        </div>
      );
    }

    const fullPath = `https://localhost:7077/api/LicenseApplication/view/${docPath}`;
    const fileExtension = docPath.split('.').pop().toLowerCase();
    
    // Check if it's an image
    if (['jpg', 'jpeg', 'png', 'gif', 'bmp', 'webp'].includes(fileExtension)) {
      return <img src={fullPath} alt={docName} />;
    }
    
    // For PDFs and other documents
    return <iframe src={fullPath} title={docName} />;
  };

  if (loading) {
    return (
      <div className="modal-overlay">
        <div className="modal-content">
          <div className="loading">Loading application details...</div>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="modal-overlay">
        <div className="modal-content">
          <button className="modal-close" onClick={onClose}>×</button>
          <div className="error">{error}</div>
        </div>
      </div>
    );
  }

  if (!formData) {
    return (
      <div className="modal-overlay">
        <div className="modal-content">
          <button className="modal-close" onClick={onClose}>×</button>
          <div className="error">No application data found</div>
        </div>
      </div>
    );
  }

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <button className="modal-close" onClick={onClose}>×</button>
        <h2 className="modal-title">License Application Details</h2>

        <div className="modal-columns">
          <div className="modal-column">
            <h3 className="section-header">
              <span className="section-icon">👤</span> Personal Information
            </h3>
            <p><strong>ID Type:</strong> {formData.idType}</p>
            <p><strong>ID Number:</strong> {formData.idNumber}</p>
            <p><strong>Surname:</strong> {formData.surname}</p>
            <p><strong>Other Names:</strong> {formData.otherNames}</p>
            <p><strong>Printed Name:</strong> {formData.printedName}</p>
            <p><strong>Height:</strong> {formData.heightFeet}' {formData.heightInches}"</p>
            <p><strong>Blood Group:</strong> {formData.bloodGroup}</p>
            <p><strong>Organ Donor:</strong> {formData.organDonor ? 'Yes' : 'No'}</p>
            <p><strong>Address:</strong> {formData.address}</p>
            <p><strong>Phone Number:</strong> {formData.phoneNumber}</p>
          </div>

          <div className="modal-column">
            <h3 className="section-header">
              <span className="section-icon">📋</span> Application Information
            </h3>
            <p><strong>Secretariat:</strong> {formData.secretariat}</p>
            <p><strong>Driver Restrictions:</strong> {formData.driverRestrictions || 'None'}</p>
            <p><strong>Status:</strong> {formData.status === 0 ? 'Pending' : formData.status === 1 ? 'Approved' : 'Rejected'}</p>
            <p><strong>Submitted At:</strong> {new Date(formData.submittedAt).toLocaleString()}</p>
          </div>
        </div>

        <div className="certificates-display">
          <h3 className="certificates-title">📄 Uploaded Certificates</h3>
          
          <div className="certificates-grid">
            <div className="certificate-card">
              <div className="certificate-header">
                <span className="certificate-name">Birth Certificate</span>
                {renderDocumentActions(formData.birthCertificatePath, 'Birth_Certificate.pdf')}
              </div>
            </div>

            <div className="certificate-card">
              <div className="certificate-header">
                <span className="certificate-name">Medical Certificate</span>
                {renderDocumentActions(formData.medicalCertificatePath, 'Medical_Certificate.pdf')}
              </div>
            </div>
          </div>
        </div>
      </div>

      {/* PDF Viewer Modal */}
      {viewingDocument && (
        <div className="pdf-viewer-overlay" onClick={() => setViewingDocument(null)}>
          <div className="pdf-viewer-modal" onClick={(e) => e.stopPropagation()}>
            <div className="pdf-viewer-header">
              <h3>{viewingDocument.name}</h3>
              <button className="pdf-close-btn" onClick={() => setViewingDocument(null)}>×</button>
            </div>
            <div className="pdf-viewer-content">
              <iframe src={viewingDocument.path} title={viewingDocument.name} />
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ApplicationDetailsModal;

