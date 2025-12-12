// Submit License Application function
import axios from "axios";

const API_URL = "https://localhost:7077/api/LicenseApplication"; // change port if needed

export const submitLicenseApplication = async (formData) => {
  try {
    const response = await axios.post(`${API_URL}/submit`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return response.data; // Returns success message and ID
  } catch (error) {
    console.error("Form submission error:", error.response?.data || error.message);
    throw error;
  }
};
