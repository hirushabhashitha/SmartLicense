import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { DataGrid } from '@mui/x-data-grid';
import Button from '@mui/material/Button';
import './DrivingSchool.css';
import Navbar from '../../Components/Navbar/Navbar';
import Footer from '../../Components/Footer/Footer';

const DrivingSchool = () => {
  const [rows, setRows] = useState([]);
  const [loading, setLoading] = useState(true); // optional: show loading state
  const navigate = useNavigate();

  useEffect(() => {
    const fetchDrivingSchools = async () => {
      try {
        const res = await fetch('https://localhost:7077/api/DrivingSchools');
        if (!res.ok) throw new Error('Failed to fetch driving schools');
        const data = await res.json();
        // Map API data to rows suitable for DataGrid
        const formattedRows = data.map((school, index) => ({
          id: index, // required by DataGrid
          school: school.drivingSchoolName || school.DrivingSchoolName, // make sure field names match API
          location: school.location || school.Location,
          contact: school.contact || school.Contact,
        }));
        setRows(formattedRows);
      } catch (error) {
        console.error(error);
      } finally {
        setLoading(false);
      }
    };

    fetchDrivingSchools();
  }, []);

  const handleApply = (school) => {
    localStorage.setItem('selectedSchool', JSON.stringify(school));
    navigate('/license-application');
  };

  const columns = [
    { field: 'school', headerName: 'Driving School', width: 200 },
    { field: 'location', headerName: 'Location', width: 150 },
    { field: 'contact', headerName: 'Contact', width: 150 },
    {
      field: 'apply',
      headerName: 'Apply',
      width: 130,
      sortable: false,
      filterable: false,
      renderCell: (params) => (
        <Button
          variant="contained"
          color="primary"
          size="small"
          onClick={() => handleApply(params.row)}
        >
          Apply
        </Button>
      ),
    },
  ];

  return (
    <>
      <Navbar />
      <div className="driving-school-page">
        <h2>Available Driving Schools</h2>
        <div className="data-grid-wrapper" style={{ minHeight: 400 }}>
          <DataGrid
            rows={rows}
            columns={columns}
            autoHeight
            loading={loading}
            hideFooter
            disableColumnMenu
            disableSelectionOnClick
          />
        </div>
      </div>
      <Footer />
    </>
  );
};

export default DrivingSchool;
