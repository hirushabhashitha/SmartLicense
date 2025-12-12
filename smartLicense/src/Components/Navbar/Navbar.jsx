import React from 'react';
import './Navbar.css';
import Topbar from '../Topbar/Topbar'; // Make sure Topbar.jsx exists
import { useNavigate } from 'react-router-dom';

const Navbar = () => {
  const navigate = useNavigate();

  return (
    <>
      <Topbar />
      <nav className="navbar">
        <div className="navbar-left">
          <img src="/licenselogo.png" alt="Logo" className="navbar-logo" />
          <span className="navbar-text">SmartLicense</span>
        </div>

        <div className="navbar-center">
          <a onClick={() => navigate('/')}>Home</a>
          <a onClick={() => navigate('/driving-school')}>Driving School</a>
          <a onClick={() => navigate('/payment')}>Payment</a>
          <a onClick={() => navigate('/exam')}>Exam</a>
          <a onClick={() => navigate('/contact')}>Contact</a>
        </div>

        <div className="navbar-right">
          <button className="btn register" onClick={() => navigate('/register')}>Register</button>
          <button className="btn login" onClick={() => navigate('/login')}>Login</button>
        </div>
      </nav>
    </>
  );
};

export default Navbar;

