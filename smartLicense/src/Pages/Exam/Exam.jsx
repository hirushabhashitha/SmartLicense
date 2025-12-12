import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { api } from "../api";
import ExamQuestion from "../components/ExamQuestion";

export default function Exam() {
  const { sessionId } = useParams();
  const navigate = useNavigate();

  const [questions, setQuestions] = useState([]);
  const [answers, setAnswers] = useState({});
  const [timeLeft, setTimeLeft] = useState(0);

  useEffect(() => {
    loadExam();
  }, []);

  const loadExam = async () => {
    try {
      // get session
      const session = await api.get(`/session/${sessionId}`);
      const end = new Date(session.data.endsAt);
      const now = new Date();
      setTimeLeft(end - now);

      // load questions
      const res = await api.get(`/questions/${session.data.examId}`);
      setQuestions(res.data);

      // restore saved answers
      const saved = localStorage.getItem(`exam_${sessionId}`);
      if (saved) setAnswers(JSON.parse(saved));

      // start timer
      startTimer(end);
    } catch (err) {
      alert("Cannot load exam");
      navigate("/");
    }
  };

  const startTimer = (end) => {
    const timer = setInterval(() => {
      const diff = end - new Date();
      setTimeLeft(diff);

      if (diff <= 0) {
        clearInterval(timer);
        submitExam(true);
      }
    }, 1000);
  };

  const handleChange = (questionId, answer) => {
    const newAns = { ...answers, [questionId]: answer };
    setAnswers(newAns);
    localStorage.setItem(`exam_${sessionId}`, JSON.stringify(newAns));
  };

  const submitExam = async (auto = false) => {
    try {
      const payload = {
        sessionId: Number(sessionId),
        answers: Object.entries(answers).map(([qid, ans]) => ({
          questionId: Number(qid),
          answer: ans,
        })),
      };

      await api.post("/submit", payload);
      localStorage.removeItem(`exam_${sessionId}`);

      alert(auto ? "Time is up — auto submitted" : "Submitted");
      navigate("/");
    } catch (err) {
      alert("Submit failed: " + err.response?.data);
    }
  };

  return (
    <div className="exam-container">
      <div className="timer">
        Time Left:{" "}
        <b>
          {Math.max(0, Math.floor(timeLeft / 1000 / 60))} min{" "}
          {Math.max(0, Math.floor((timeLeft / 1000) % 60))} sec
        </b>
      </div>

      {questions.map((q, i) => (
        <ExamQuestion
          key={q.id}
          qIndex={i}
          question={q}
          answer={answers[q.id]}
          onChange={handleChange}
        />
      ))}

      <button className="submit-btn" onClick={() => submitExam(false)}>
        Submit Exam
      </button>
    </div>
  );
}
