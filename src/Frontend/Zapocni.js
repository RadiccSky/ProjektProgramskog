import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; // Inicijaliziramo useNavigate
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  IconButton,
  Typography,
  Box,
  Button,
} from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import HomeIcon from '@mui/icons-material/Home';
import ArchiveIcon from '@mui/icons-material/Archive';
import InfoIcon from '@mui/icons-material/Info';
import '@fontsource/dancing-script'; // Uvoz fonta

function Zapocni() {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const [selectedPlan, setSelectedPlan] = useState(null); // State for selected plan details
  const navigate = useNavigate(); // Inicijaliziramo navigate funkciju

  const toggleDrawer = (open) => () => {
    setDrawerOpen(open);
  };

  const menuItems = [
    { text: "Početna", icon: <HomeIcon />, action: () => navigate("/") },
    { text: "Povijest vjenčanja", icon: <ArchiveIcon />, action: () => navigate("/povijest-svadbi") },
    { text: "O nama", icon: <InfoIcon />, action: () => navigate("/onama") },
  ];

  const plans = {
    jeftino: {
      title: 'Jeftino',
      details: ['Bend: dj', 'Sala: stara sala', 'Fotograf: mobitel'],
    },
    srednje: {
      title: 'Srednje',
      details: ['Bend: deja vu', 'Sala: srednja sala', 'Fotograf: SBP'],
    },
    skupo: {
      title: 'Skupo',
      details: ['Bend: hit', 'Sala: nova sala', 'Fotograf: amigo'],
    },
  };

  const handleButtonClick = (plan) => {
    setSelectedPlan(plans[plan]);
  };

  return (
    <div
      style={{
        height: '100vh',
        display: 'flex',
        flexDirection: 'column',
        backgroundImage: 'url("/list.gif")',
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundAttachment: 'fixed',
        backgroundSize: 'cover',
      }}
    >
      {/* Drawer Section */}
      <IconButton
        onClick={toggleDrawer(true)}
        style={{ position: 'absolute', top: 16, left: 16, color: 'purple' }}
      >
        <MenuIcon fontSize="large" />
      </IconButton>

      <Drawer anchor="left" open={drawerOpen} onClose={toggleDrawer(false)}>
        <Box
          sx={{
            width: 250,
            height: '100%',
            backgroundColor: 'purple',
            color: 'white',
            padding: '16px',
          }}
        >
          <Typography variant="h5" style={{ marginBottom: '16px', textAlign: 'center' }}>
            Izbornik
          </Typography>
          <List>
            {menuItems.map((item, index) => (
              <ListItem button
                key={index}
                onClick={item.action}
                sx={{
                  cursor: 'pointer',
                  '&:hover': { backgroundColor: 'rgba(255, 255, 255, 0.2)' },
                }}>
                <ListItemIcon style={{ color: 'white' }}>{item.icon}</ListItemIcon>
                <ListItemText primary={item.text} style={{ color: 'white' }} />
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>

      {/* Main Content */}
      <Box
        sx={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          flexGrow: 1,
          backgroundColor: '#fbeff7',
          flexDirection: 'column',
          padding: '20px',
        }}
      >
        <Typography
          variant="h3"
          style={{
            textAlign: 'center',
            fontFamily: "'Dancing Script', cursive",
            color: 'purple',
            marginBottom: '20px',
            fontWeight: 'bold',
          }}
        >
          Kreiranje planera za vjenčanje
        </Typography>

        <hr style={{ borderTop: '2px solid purple', width: 'calc(100% - 40px)', marginBottom: '20px' }} />

        {/* Buttons for Jeftino, Srednje, and Skupo */}
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'space-between',
            width: '100%',
            maxWidth: '800px',
            marginBottom: '40px',
          }}
        >
          <Button
            variant="contained"
            style={{
              backgroundColor: 'purple',
              color: 'white',
              padding: '10px 20px',
              borderRadius: '20px',
              fontSize: '16px',
              textTransform: 'none',
              boxShadow: '0px 4px 6px rgba(0, 0, 0, 0.1)',
            }}
            onClick={() => handleButtonClick('jeftino')}
          >
            Jeftino
          </Button>
          <Button
            variant="contained"
            style={{
              backgroundColor: 'purple',
              color: 'white',
              padding: '10px 20px',
              borderRadius: '20px',
              fontSize: '16px',
              textTransform: 'none',
              boxShadow: '0px 4px 6px rgba(0, 0, 0, 0.1)',
            }}
            onClick={() => handleButtonClick('srednje')}
          >
            Srednje
          </Button>
          <Button
            variant="contained"
            style={{
              backgroundColor: 'purple',
              color: 'white',
              padding: '10px 20px',
              borderRadius: '20px',
              fontSize: '16px',
              textTransform: 'none',
              boxShadow: '0px 4px 6px rgba(0, 0, 0, 0.1)',
            }}
            onClick={() => handleButtonClick('skupo')}
          >
            Skupo
          </Button>
        </Box>

        {/* Display the selected plan details */}
        {selectedPlan && (
          <Box
            sx={{
              backgroundColor: 'white',
              padding: '20px',
              borderRadius: '5px',
              boxShadow: '0 2px 5px rgba(0, 0, 0, 0.1)',
              width: '80%',
              maxWidth: '600px',
              marginTop: '20px',
            }}
          >
            <Typography variant="h6" style={{ color: 'purple', marginBottom: '10px' }}>
              Plan: {selectedPlan.title}
            </Typography>
            <ul>
              {selectedPlan.details.map((item, index) => (
                <li key={index}>
                  <Typography variant="body1" style={{ color: 'purple' }}>
                    {item}
                  </Typography>
                </li>
              ))}
            </ul>
          </Box>
        )}

        <div
          style={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
            width: '15%',
            height: '150px',
            backgroundColor: '#ffffff',
            border: '1px solid #ccc',
            borderRadius: '5px',
            marginLeft: '50px',
            cursor: 'pointer',
            boxShadow: '0 2px 5px rgba(0, 0, 0, 0.1)',
            marginTop: '100px',
            fontSize: '20px',
            fontWeight: 'bold',
          }}
          onMouseEnter={(e) => (e.currentTarget.style.backgroundColor = '#f0d9f0')}
          onMouseLeave={(e) => (e.currentTarget.style.backgroundColor = '#ffffff')}
          onClick={() => navigate('/create-wedding')}  // Navigacija na /create-wedding
        >
          <div style={{ fontSize: '50px', fontWeight: 'bold' }}>+</div>
          <p>Stvorite svoje vjenčanje</p>
        </div>
      </Box>

      {/* Footer Section */}
      <Box
        sx={{
          backgroundColor: 'purple',
          color: 'white',
          padding: '10px',
          textAlign: 'right',
          marginTop: 'auto',
        }}
      >
        <Typography variant="body1" style={{ fontSize: '12px' }}>
          Grupa PI05 &copy; 2024/2025
        </Typography>
      </Box>
    </div>
  );
}

export default Zapocni;
