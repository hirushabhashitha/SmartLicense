import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; // 👈 import useNavigate
import './CardPaymentPage.css';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';
import ModalNotification from '../../Components/ModalNotification/ModalNotification';

const CardPaymentPage = () => {
  const [cardDetails, setCardDetails] = useState({
    cardNumber: '',
    cardName: '',
    expiryDate: '',
    cvv: '',
  });

  const [showModal, setShowModal] = useState(false);
  const navigate = useNavigate(); // 👈 initialize navigate

  const handleChange = (e) => {
    setCardDetails({ ...cardDetails, [e.target.name]: e.target.value });
  };

  const handlePayment = (e) => {
    e.preventDefault();

    // You can add actual payment logic here
    setShowModal(true); // show modal on "success"
  };

  const handleModalClose = () => {
    setShowModal(false);
    navigate('/exam'); // 👈 navigate to DataCardClick page
  };

  return (
    <>
      <Navbar />
      <div className="card-payment-container">
        <h2>Card Payment</h2>
        <form className="payment-form" onSubmit={handlePayment}>
          <label>
            Card Number
            <input
              type="text"
              name="cardNumber"
              maxLength="16"
              value={cardDetails.cardNumber}
              onChange={handleChange}
              required
              placeholder="1234 5678 9012 3456"
            />
          </label>

          <label>
            Cardholder Name
            <input
              type="text"
              name="cardName"
              value={cardDetails.cardName}
              onChange={handleChange}
              required
              placeholder="John Doe"
            />
          </label>

          <div className="row">
            <label>
              Expiry Date
              <input
                type="month"
                name="expiryDate"
                value={cardDetails.expiryDate}
                onChange={handleChange}
                required
              />
            </label>

            <label>
              CVV
              <input
                type="password"
                name="cvv"
                maxLength="3"
                value={cardDetails.cvv}
                onChange={handleChange}
                required
                placeholder="123"
              />
            </label>
          </div>

          <button type="submit" className="pay-button">Pay Now</button>
        </form>
      </div>

      {showModal && (
        <ModalNotification
          title="Payment Successful"
          message="Your payment has been processed successfully!"
          buttonText="OK"
          onClose={handleModalClose}
        />
      )}

      <Footer />
    </>
  );
};

export default CardPaymentPage;
