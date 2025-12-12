import axios from "axios";

const API_URL = "https://localhost:7077/api/Exam"; // ASP.NET backend URL

// Start exam
export const startExam = async (data) => {
  const res = await axios.post(`${API_URL}/start`, data);
  return res.data;
};

// Get 40 questions
export const getQuestions = async (examId) => {
  const res = await axios.get(`${API_URL}/questions/${examId}`);
  return res.data;
};

// Get session info
export const getSession = async (sessionId) => {
  const res = await axios.get(`${API_URL}/session/${sessionId}`);
  return res.data;
};

// Submit answers
export const submitExam = async (payload) => {
  const res = await axios.post(`${API_URL}/submit`, payload);
  return res.data;
};
