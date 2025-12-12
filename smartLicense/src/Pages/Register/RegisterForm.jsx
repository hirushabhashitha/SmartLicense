import React, { useState } from 'react';
import './RegisterForm.css';
import { FaUser, FaEnvelope, FaLock } from 'react-icons/fa';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';
import { useNavigate } from 'react-router-dom';
import { registerUser } from '../../api/auth'; 
import ModalNotification from '../../Components/ModalNotification/ModalNotification'; // ✅ import modal

const RegisterForm = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
  });

  const [modal, setModal] = useState({
    open: false,
    title: '',
    message: '',
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (formData.password !== formData.confirmPassword) {
      setModal({
        open: true,
        title: 'Error',
        message: 'Passwords do not match!',
      });
      return;
    }

    try {
      const response = await registerUser({
        name: formData.name,
        email: formData.email,
        password: formData.password,
      });

      console.log('Register success:', response);

      setModal({
        open: true,
        title: 'Success',
        message: 'Registration successful!',
      });

      // close modal & redirect after short delay
      setTimeout(() => {
        setModal({ open: false, title: '', message: '' });
        navigate('/login');
      }, 2000);

    } catch (error) {
      console.error('Register failed:', error);
      setModal({
        open: true,
        title: 'Error',
        message: error?.response?.data?.message || 'Registration failed. Please try again.',
      });
    }
  };

  return (
    <>
      <Navbar />

      <div className="register-container">
        <form onSubmit={handleSubmit} className="register-form">
          <h2 className="register-title">Register</h2>
          <p className="register-subtitle">
            Please enter your Name, Email, and Password
          </p>

          <div className="input-wrapper">
            <FaUser className="input-icon" />
            <input
              type="text"
              name="name"
              placeholder="Username"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </div>

          <div className="input-wrapper">
            <FaEnvelope className="input-icon" />
            <input
              type="email"
              name="email"
              placeholder="Email"
              value={formData.email}
              onChange={handleChange}
              required
            />
          </div>

          <div className="input-wrapper">
            <FaLock className="input-icon" />
            <input
              type="password"
              name="password"
              placeholder="Password"
              value={formData.password}
              onChange={handleChange}
              required
            />
          </div>

          <div className="input-wrapper">
            <FaLock className="input-icon" />
            <input
              type="password"
              name="confirmPassword"
              placeholder="Re-enter Password"
              value={formData.confirmPassword}
              onChange={handleChange}
              required
            />
          </div>

          <button type="submit" className="register-button">
            Register
          </button>

          <p className="login-text">
            Already have an Account?{' '}
            <span
              className="login-link"
              onClick={() => navigate('/login')}
              style={{ cursor: 'pointer', color: 'blue' }}
            >
              Login
            </span>
          </p>
        </form>
      </div>

      <Footer />

      {/* ✅ Modal Notification */}
      {modal.open && (
        <ModalNotification
          title={modal.title}
          message={modal.message}
          buttonText="OK"
          onClose={() => setModal({ open: false, title: '', message: '' })}
        />
      )}
    </>
  );
};

export default RegisterForm;

