import React from "react";
import { useNavigate } from "react-router-dom";
import "./GuideLineForm.css";

const GuidelineForm = ({ onProceed }) => {
  const navigate = useNavigate();

  const handleProceed = () => {
    if (onProceed) {
      onProceed();
    } else {
      navigate('/exam-page');
    }
  };

  return (
    <div className="guideline-form-container">
      <div className="guideline-box">
        <h2>Exam Guidelines</h2>
        <ul>
          <li>You will have 60 minutes to complete the exam.</li>
          <li>The exam consists of 50 multiple choice questions.</li>
          <li>Read all questions carefully before answering.</li>
          <li>You cannot go back once you submit the exam.</li>
          <li>Click "Proceed" to begin the exam.</li>
        </ul>
        <button className="proceed-btn" onClick={handleProceed}>
          Proceed to Exam
        </button>
      </div>
    </div>
  );
};

export default GuidelineForm;
