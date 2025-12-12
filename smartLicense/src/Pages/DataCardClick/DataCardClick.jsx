import React, { useEffect, useState } from 'react';
import './DataCardClick.css';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';
import { MdVisibility } from 'react-icons/md';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import ModalNotification from '../../Components/ModalNotification/ModalNotification';
import ApplicationDetailsModal from '../ApplicationDetailsModal/ApplicationDetailsModal';

const DataCardClick = () => {
  const [applications, setApplications] = useState([]);
  const [modal, setModal] = useState({ open: false, title: "", message: "" });
  const [showDetailsModal, setShowDetailsModal] = useState(false);
  const [selectedApplicationId, setSelectedApplicationId] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const storedUserId = localStorage.getItem("userId");

    axios
      .get(`https://localhost:7077/api/DataCardClick?id=${storedUserId}`)
      .then((res) => {
        const data = res.data.data || res.data;
        if (Array.isArray(data)) setApplications(data);
        else setApplications([]);
      })
      .catch((err) => console.error("Error fetching data:", err));
  }, []);

  const handlePaymentClick = (app) => {
    // Status 1 = Approved (handle both string and number)
    if (app.status === 1 || app.status === "1" || app.status === "Approve") {
      navigate('/application-fee', { state: { applicationId: app.id } });
    }
  };

  const handleExamClick = (app) => {
    // Status 1 = Approved (handle both string and number)
    if (app.status === 1 || app.status === "1" || app.status === "Approve") {
      navigate('/exam-page');
    } else {
      // For testing - navigate anyway
      navigate('/exam-page');
    }
  };

  const isApproved = (status) => {
    return status === 1 || status === "1" || status === "Approve";
  };

  const statusMap = {
    0: "Pending",
    1: "Approve",
    2: "Reject"
  };

  const getStatusClass = (status) => {
    if (status === 0) return "status-badge status-pending";
    if (status === 1) return "status-badge status-approved";
    if (status === 2) return "status-badge status-rejected";
    return "status-badge";
  };

  return (
    <>
      <Navbar />
      <h2 className="datacardclick-title">License Application Summary</h2>

      {applications.length === 0 ? (
        <p>No applications found.</p>
      ) : (
        <div className="datacardclick-wrapper">
          {applications.map((app, index) => (
            <div className="datacardclick-container" key={index}>
              <div className="datacardclick-card">
                <div className="data-row">
                  <div className="label-group">
                    <span className="label">ID Number</span>
                    <span className="colon">:</span>
                  </div>
                  <span className="value">{app.idNumber || 'N/A'}</span>
                </div>

                <div className="data-row">
                  <div className="label-group">
                    <span className="label">Surname</span>
                    <span className="colon">:</span>
                  </div>
                  <span className="value">{app.surname || 'N/A'}</span>
                </div>

                <div className="data-row">
                  <div className="label-group">
                    <span className="label">Phone Number</span>
                    <span className="colon">:</span>
                  </div>
                  <span className="value">{app.phoneNumber || 'N/A'}</span>
                </div>

                <div className="data-row">
                  <div className="label-group">
                    <span className="label">Status</span>
                    <span className="colon">:</span>
                  </div>
                  <span className={getStatusClass(app.status)}>
                    {statusMap[app.status] ?? "Unknown"}
                  </span>
                </div>

                <div className="action-row">
             <MdVisibility
  className="eye-icon"
  title="View Details"
  onClick={() => {
    setSelectedApplicationId(app.id);
    setShowDetailsModal(true);
  }}
/>


                  <button
                    className="payment-button"
                    onClick={() => handlePaymentClick(app)}
                    disabled={!isApproved(app.status)}
                  >
                    Payment
                  </button>
                  <button
                    className="exam-button"
                    onClick={() => handleExamClick(app)}
                  >
                    Go To The Exam
                  </button>
                </div>

                {app.status === 0 && (
                  <p className="payment-notice">
                    You can proceed once your application is approved by the admin.
                  </p>
                )}
                {app.status === 1 && (
                  <p className="payment-notice" style={{ color: 'green' }}>Your application is approved. You can proceed to payment and exam.</p>
                )}
                {app.status === 2 && (
                  <p className="payment-notice" style={{ color: 'red' }}>Your application has been rejected.</p>
                )}
              </div>
            </div>
          ))}
        </div>
      )}

      {/* ✅ Render Modal */}
      {modal.open && (
        <ModalNotification
          open={modal.open}
          title={modal.title}
          message={modal.message}
          onClose={() => setModal({ ...modal, open: false })}
        />
      )}

      {/* ✅ Render Application Details Modal */}
      {showDetailsModal && (
        <ApplicationDetailsModal
          onClose={() => setShowDetailsModal(false)}
          applicationId={selectedApplicationId}
        />
      )}

      <Footer />
    </>
  );
};

export default DataCardClick;


