// src/api/auth.js
import axios from "axios";

const API_URL = "https://localhost:7077/api/Auth"; // ASP.NET backend URL

// Register function
export const registerUser = async (userData) => {
  try {
    const response = await axios.post(`${API_URL}/register`, userData);
    return response.data;
  } catch (error) {
    console.error("Register error:", error.response?.data || error.message);
    throw error;
  }
};

// Login function
export const loginUser = async (loginData) => {
  try {
    const response = await axios.post(`${API_URL}/login`, loginData);
    return response.data;
  } catch (error) {
    console.error("Login error:", error.response?.data || error.message);
    throw error;
  }
};
