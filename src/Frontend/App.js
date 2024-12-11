import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, useNavigate } from "react-router-dom";
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
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import HomeIcon from "@mui/icons-material/Home";
import InfoIcon from "@mui/icons-material/Info";
import ArchiveIcon from "@mui/icons-material/Archive";
import "@fontsource/dancing-script";

import PovijestSvadbi from "./PovijestSvadbi";
import Zapocni from "./Zapocni";
import NovoVjencanje from './NovoVjencanje'; // Import NovoVjencanje
import ONama from './ONama'; // Import the ONama component

function HomePage() {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const navigate = useNavigate();

  const toggleDrawer = (open) => () => {
    setDrawerOpen(open);
  };

  const menuItems = [
    { text: "Pocetna", icon: <HomeIcon />, action: () => navigate("/") },
    { text: "Povijest vjenčanja", icon: <ArchiveIcon />, action: () => navigate("/povijest-svadbi") },
    { text: "O nama", icon: <InfoIcon />, action: () => navigate("/onama") }, // Navigate to /onama
  ];

  return (
    <div
      style={{
        height: "100vh",
        display: "flex",
        flexDirection: "column",
        backgroundImage: "url('/list.gif')",
        backgroundRepeat: "no-repeat",
        backgroundPosition: "center center",
        backgroundAttachment: "fixed",
        backgroundSize: "cover",
      }}
    >
      <IconButton
        onClick={toggleDrawer(true)}
        style={{ position: "absolute", top: 16, left: 16, color: "purple" }}
      >
        <MenuIcon fontSize="large" />
      </IconButton>

      <Drawer anchor="left" open={drawerOpen} onClose={toggleDrawer(false)}>
        <Box
          sx={{
            width: 250,
            height: "100%",
            backgroundColor: "purple",
            color: "white",
            padding: "16px",
          }}
        >
          <Typography variant="h5" style={{ marginBottom: "16px", textAlign: "center" }}>
            Izbornik
          </Typography>
          <List>
            {menuItems.map((item, index) => (
              <ListItem button 
                key={index} 
                onClick={item.action}
                sx={{
                  cursor: "pointer",
                  "&:hover": { backgroundColor: "rgba(255, 255, 255, 0.2)" },
                }}>
                <ListItemIcon style={{ color: "white" }}>{item.icon}</ListItemIcon>
                <ListItemText primary={item.text} style={{ color: "white" }} />
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>

      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          flexGrow: 1,
          backgroundColor: "#fbeff7",
          flexDirection: "column",
          padding: "20px",
        }}
      >
        <Typography
          variant="h3"
          style={{
            textAlign: "center",
            fontFamily: "'Dancing Script', cursive",
            color: "purple",
            marginBottom: "20px",
            fontWeight: "bold",
          }}
        >
          Dobrodošli na web stranicu za planiranje vjenčanja
        </Typography>

        <Button
          variant="contained"
          style={{
            backgroundColor: "purple",
            color: "white",
            padding: "10px 20px",
            borderRadius: "20px",
            fontSize: "16px",
            textTransform: "none",
            boxShadow: "0px 4px 6px rgba(0, 0, 0, 0.1)",
            marginTop: "20px",
          }}
          onClick={() => navigate("/zapocni")} // Navigacija na /zapocni
        >
          ZAPOČNI
        </Button>
      </Box>

      <Box
        sx={{
          backgroundColor: "purple",
          color: "white",
          padding: "10px",
          textAlign: "right",
          marginTop: "auto",
        }}
      >
        <Typography variant="body1" style={{ fontSize: "12px" }}>
          Grupa PI05 &copy; 2024/2025
        </Typography>
      </Box>
    </div>
  );
}

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/povijest-svadbi" element={<PovijestSvadbi />} />
        <Route path="/zapocni" element={<Zapocni />} />
        <Route path="/create-wedding" element={<NovoVjencanje />} />
        <Route path="/onama" element={<ONama />} /> {/* Added route for ONama */}
      </Routes>
    </Router>
  );
}

export default App;
