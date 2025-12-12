import React from 'react';
import './HomePage.css';
import { useNavigate } from 'react-router-dom'; // ✅ Import this
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';
import FeatureSection from '../../Components/Feature/FeatureSection';

const HomePage = () => {
  const navigate = useNavigate(); // ✅ Initialize navigation

  return (
    <>
      <Navbar />
      <div className="home-hero">
        <div className="hero-content">
          <h1>Welcome to SmartLicense</h1>
          <p>Your one-stop solution for applying and tracking your driving license application.</p>
          <button className="hero-button" onClick={() => navigate('/register')}>
            Get Started
          </button>
        </div>
      </div>
      <FeatureSection />
      <Footer />
    </>
  );
};

export default HomePage;
