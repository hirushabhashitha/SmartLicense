import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { FaEnvelope, FaLock } from "react-icons/fa";
import Navbar from "../../Components/Navbar/Navbar";
import Footer from "../../Components/Footer/Footer";
import ModalNotification from "../../Components/ModalNotification/ModalNotification";
import { loginUser } from "../../api/auth"; // ✅ axios API call
import "./Login.css";

const LoginForm = () => {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const [modal, setModal] = useState({
    open: false,
    title: "",
    message: "",
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const res = await loginUser(formData); // axios POST call
      console.log("API response", res);

      // setModal({
      //   open: true,
      //   title: "Login Successful 🎉",
      //   message: (
      //     <div>
      //       <p>Welcome back!</p>
      //       <p>
      //         <strong>Name:</strong> {response.user?.name}
      //       </p>
      //       <p>
      //         <strong>Email:</strong> {response.user?.email}
      //       </p>
      //     </div>
      //   ),
      // });

      // ✅ Save userId separately
      if (res.id) {
        localStorage.setItem("userId", res.id);
      }

    

      // Redirect after short delay
      setTimeout(() => {
        setModal({ open: false, title: "", message: "" });
        navigate("/driving-school");
      }, 2000);
    } catch (error) {
      console.error("Login failed:", error);

      const message =
        (error.response && error.response.data && error.response.data.message) ||
        error.message ||
        "Invalid email or password";

      setModal({
        open: true,
        title: "Login Failed ❌",
        message,
      });
    }
  };

  return (
    <>
      <Navbar />

      <div className="login-container">
        <form onSubmit={handleSubmit} className="login-form">
          <h2 className="login-title">Login</h2>

          <div className="input-wrapper">
            <FaEnvelope className="input-icon" />
            <input
              type="email"
              name="email"
              placeholder="Email"
              value={formData.email}
              onChange={handleChange}
              required
            />
          </div>

          <div className="input-wrapper">
            <FaLock className="input-icon" />
            <input
              type="password"
              name="password"
              placeholder="Password"
              value={formData.password}
              onChange={handleChange}
              required
            />
          </div>

          <button type="submit" className="login-button">
            Login
          </button>
        </form>
      </div>

      <Footer />

      {/* ✅ Modal Notification */}
      {modal.open && (
        <ModalNotification
          title={modal.title}
          message={modal.message}
          buttonText="OK"
          onClose={() => setModal({ open: false, title: "", message: "" })}
        />
      )}
    </>
  );
};

export default LoginForm;


