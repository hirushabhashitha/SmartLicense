import React, { useState, useEffect } from 'react';
import './ExamPage.css';

const generateQuestions = () => {
  const questions = [];
  for (let i = 1; i <= 50; i++) {
    questions.push({
      id: i,
      question: `Question ${i}: What is the answer to this MCQ?`,
      options: ['Option A', 'Option B', 'Option C', 'Option D'],
      answer: null,
    });
  }
  return questions;
};

const ExamPage = () => {
  const [questions, setQuestions] = useState(generateQuestions());
  const [currentPage, setCurrentPage] = useState(1);
  const [timeLeft, setTimeLeft] = useState(60 * 60); // 10 minutes

  const questionsPerPage = 10;
  const totalPages = Math.ceil(questions.length / questionsPerPage);

  const startIndex = (currentPage - 1) * questionsPerPage;
  const currentQuestions = questions.slice(startIndex, startIndex + questionsPerPage);

  useEffect(() => {
    const timer = setInterval(() => {
      setTimeLeft((prev) => {
        if (prev === 1) {
          handleSubmit(); // Auto-submit when time runs out
          clearInterval(timer);
        }
        return prev - 1;
      });
    }, 1000);

    return () => clearInterval(timer);
  }, []);

  const formatTime = (seconds) => {
    const mins = Math.floor(seconds / 60).toString().padStart(2, '0');
    const secs = (seconds % 60).toString().padStart(2, '0');
    return `${mins}:${secs}`;
  };

  const handleOptionChange = (questionId, selectedOption) => {
    const updated = questions.map((q) =>
      q.id === questionId ? { ...q, answer: selectedOption } : q
    );
    setQuestions(updated);
  };

  const handleSubmit = () => {
    alert('Exam submitted!');
    console.log('Submitted Answers:', questions);
  };

  return (
    <div className="exam-container">
      <div className="exam-header">
        <h2>MCQ Exam</h2>
        <div className="timer">⏱ Time Left: {formatTime(timeLeft)}</div>
      </div>

      <div className="questions-list">
        {currentQuestions.map((q) => (
          <div key={q.id} className="question-card">
            <p>{q.question}</p>
            <div className="options">
              {q.options.map((option, index) => (
                <label key={index}>
                  <input
                    type="radio"
                    name={`question-${q.id}`}
                    value={option}
                    checked={q.answer === option}
                    onChange={() => handleOptionChange(q.id, option)}
                  />
                  {option}
                </label>
              ))}
            </div>
          </div>
        ))}
      </div>

      <div className="pagination">
        <button
          onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
          disabled={currentPage === 1}
        >
          Prev
        </button>
        <span>
          Page {currentPage} of {totalPages}
        </span>
        <button
          onClick={() => setCurrentPage((prev) => Math.min(prev + 1, totalPages))}
          disabled={currentPage === totalPages}
        >
          Next
        </button>
      </div>

      <button className="submit-btn" onClick={handleSubmit}>
        Submit Exam
      </button>
    </div>
  );
};

export default ExamPage;
