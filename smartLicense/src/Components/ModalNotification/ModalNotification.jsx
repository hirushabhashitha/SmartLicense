import React from 'react';
import './ModalNotification.css';

const ModalNotification = ({ title = "Notification", message, buttonText = "Ok", onClose }) => {
  // overlay click => close, modal box click => don't close
  const handleOverlayClick = () => {
    if (onClose) onClose();
  };

  const handleModalClick = (e) => {
    e.stopPropagation(); // prevent closing when clicking inside modal
  };

  return (

    
    <div className="modal-overlay" onClick={handleOverlayClick}>
      <div className="modal" onClick={handleModalClick}>
        
        <h3>{title}</h3>
        <div className="modal-message">
          {typeof message === 'string' ? <p>{message}</p> : message}
        </div>
        <button onClick={onClose} className="close-modal-btn">{buttonText}</button>
      </div>
    </div>
  );
};

export default ModalNotification;

