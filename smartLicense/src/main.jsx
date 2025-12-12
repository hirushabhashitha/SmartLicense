import React from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App.jsx';
import {
  createBrowserRouter,
  RouterProvider,
} from 'react-router-dom';

import RegisterForm from './Pages/Register/RegisterForm.jsx';
import LoginForm from './Pages/Login/Login.jsx';
import DrivingSchool from './Pages/DrivingSchool/DrivingSchool.jsx';
import LicenseApplicationForm from './Pages/LicenseApplicationForm/LicenseApplicationForm.jsx';
import DataCardClick from './Pages/DataCardClick/DataCardClick.jsx';
import ApplicationFee from './Pages/ApplicationFee/ApplicationFee.jsx';
import CardPaymentPage from './Pages/CardPaymentPage/CardPaymetPage.jsx';
import GuidelineForm from './Pages/GuideLineForm/GuideLineForm.jsx';
import ExamPage from './Pages/ExamPage/ExamPage.jsx';

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
  },
  {
    path: '/register',
    element: <RegisterForm />,
  },
  {
    path: '/login',
    element: <LoginForm />,
  },
  {
    path: '/driving-school',
    element: <DrivingSchool />, 
  },
  {
  path: '/license-application',
  element: <LicenseApplicationForm /> 
},
  {
    path: '/application-summary',
    element: <DataCardClick />,
  },
  {
    path: '/guidline',
    element: <GuidelineForm />,
  },
  {
    path: '/exam',
    element: <DataCardClick />,
  },
  {
    path: '/exam-page',
    element: <ExamPage />,
  },
  {
    path: '/application-fee',
    element: <ApplicationFee />,
  },
   {
    path: '/payment',
    element: <CardPaymentPage />,
  },


]);

createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
