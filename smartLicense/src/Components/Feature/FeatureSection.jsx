import React, { useEffect, useRef, useState } from 'react';
import './FeatureSection.css';

function FeatureSection() {
  const sectionRef = useRef(null);
  const [isVisible, setIsVisible] = useState(false);

  useEffect(() => {
    const observer = new IntersectionObserver(
      ([entry]) => {
        if (entry.isIntersecting) {
          setIsVisible(true);
          observer.disconnect(); // Stop observing after it becomes visible
        }
      },
      { threshold: 0.2 }
    );

    if (sectionRef.current) {
      observer.observe(sectionRef.current);
    }

    return () => observer.disconnect();
  }, []);

  return (
    <section
      ref={sectionRef}
      className={`features-section ${isVisible ? 'fade-in-up' : ''}`}
    >
      <h2 className="features-title">
        "SmartLicense makes applying for your driving license"
      </h2>
      <div className="features-grid">
        <div className="feature-card">
          <img src="/tral/tral.jpg" alt="Easy Application" className="feature-icon" />
          <h3>Easy Application</h3>
          <p>Apply for your driving license in just a few steps.</p>
        </div>

        <div className="feature-card">
          <img src="/tral/tral1.jpg" alt="Track Progress" className="feature-icon" />
          <h3>Track Progress</h3>
          <p>Track your application status in real-time.</p>
        </div>

        <div className="feature-card">
          <img src="/tral/tral3.jpg" alt="Secure Payments" className="feature-icon" />
          <h3>Secure Payments</h3>
          <p>Make secure payments for your application.</p>
        </div>
      </div>
    </section>
  );
}

export default FeatureSection;
