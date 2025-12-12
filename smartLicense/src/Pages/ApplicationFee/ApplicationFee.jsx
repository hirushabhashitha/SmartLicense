import React from 'react';
import './ApplicationFee.css';
import { useNavigate } from 'react-router-dom';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';

const ApplicationFee = () => {
  const navigate = useNavigate();

  const licenseFee = 2000;
  const drivingSchoolFee = 3500;
  const taxRate = 0.1; // 10% tax

  const subtotal = licenseFee + drivingSchoolFee;
  const taxFee = subtotal * taxRate;
  const totalFee = subtotal + taxFee;

  const handleProceedToPay = () => {
    navigate('/payment'); // Redirect to card payment page
  };

  return (
    <>
      <Navbar />
      <div className="application-fee-container">
        <h2 className="application-fee-title">License Application Fees</h2>
        <div className="application-fee-box">
          <p className="application-fee-item">
            <span>License Application Fee:</span>
            <span>Rs. {licenseFee.toLocaleString()}.00</span>
          </p>
          <p className="application-fee-item">
            <span>Driving School Fee:</span>
            <span>Rs. {drivingSchoolFee.toLocaleString()}.00</span>
          </p>
          <p className="application-fee-item">
            <span>Tax (10%):</span>
            <span>Rs. {taxFee.toLocaleString(undefined, { minimumFractionDigits: 2 })}</span>
          </p>
          <p className="application-fee-item total">
            <span>Total Fee:</span>
            <span>Rs. {totalFee.toLocaleString(undefined, { minimumFractionDigits: 2 })}</span>
          </p>

          <button className="proceed-payment-btn" onClick={handleProceedToPay}>
  Proceed to Payment
</button>

        </div>
      </div>
      <Footer />
    </>
  );
};

export default ApplicationFee;
