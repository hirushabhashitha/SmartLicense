import React from 'react';
import './Footer.css';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-left">
        <div className="footer-brand">
          <img src="/govermentlogo.jpg" alt="Logo" className="footer-logo" />
          <h2 className="footer-title">Department Of Motor Traffic</h2>
        </div>
        <ul className="footer-links">
          <li><a href="#">About</a></li>
          <li><a href="#">Privacy Policy</a></li>
          <li><a href="#">Press</a></li>
          <li><a href="#">Customer Care</a></li>
          <li><a href="#">News Letter</a></li>
        </ul>
      </div>

      <div className="footer-right">
        <p className="subscribe-text">Your email address...</p>
        <div className="subscribe-form">
          <input type="email" placeholder="Enter your email" />
          <button>Subscribe</button>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
