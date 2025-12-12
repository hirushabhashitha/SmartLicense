import React from 'react';
import './Topbar.css';

const Topbar = () => {
  return (
    <div className="topbar">
      <div className="topbar-center">
        <div className="topbar-logo-wrapper">
          <img src="/govermentlogo.jpg" alt="Logo" className="topbar-logo" />
        </div>
        <div className="topbar-text-wrapper">
          <span className="topbar-text">Department Of Motor Traffic</span>
        </div>
      </div>

      <div className="topbar-right-links">
        <a href="#">Sinhala</a>
        <a href="#">English</a>
      </div>
    </div>
  );
};

export default Topbar;



