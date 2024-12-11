import React, { useState } from "react";
import {
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Box,
  Drawer,
  IconButton,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Typography,
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import HomeIcon from "@mui/icons-material/Home";
import ArchiveIcon from "@mui/icons-material/History";
import InfoIcon from "@mui/icons-material/Info";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { useNavigate } from "react-router-dom";

function PovijestSvadbi() {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const navigate = useNavigate();

  const toggleDrawer = (open) => () => {
    setDrawerOpen(open);
  };

  const menuItems = [
    { text: "Početna", icon: <HomeIcon />, action: () => navigate("/") },
    { text: "Povijest vjenčanja", icon: <ArchiveIcon />, action: () => navigate("/povijest-svadbi") },
    { text: "O nama", icon: <InfoIcon />, action: () => navigate("/onama") },
  ];

  const weddings = [
    { title: "Svadba1", content: "Sadržaj svadbe" },
    { title: "Svadba2", content: "Sadržaj svadbe" },
    { title: "Svadba3", content: "Sadržaj svadbe" },
  ];

  return (
    <div style={{ display: "flex", flexDirection: "column", height: "100vh", backgroundColor: "#f3f3f3" }}>
      {/* Drawer Button */}
      <IconButton
        onClick={toggleDrawer(true)}
        style={{ position: "absolute", top: 16, left: 16, color: "purple" }}
      >
        <MenuIcon fontSize="large" />
      </IconButton>

      {/* Drawer */}
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
          <Typography variant="h5" style={{ marginBottom: "8px", textAlign: "center" }}>
            Izbornik
          </Typography>
          <hr style={{ border: "1px solid white", marginBottom: "16px" }} />
          <List>
            {menuItems.map((item, index) => (
              <ListItem
                button
                key={index}
                onClick={item.action}
                sx={{
                  cursor: "pointer", // Promjena kursora na pointer (ikona prsta)
                  "&:hover": { backgroundColor: "rgba(255, 255, 255, 0.2)" }, // Efekt hovera
                }}
              >
                <ListItemIcon style={{ color: "white" }}>{item.icon}</ListItemIcon>
                <ListItemText primary={item.text} style={{ color: "white" }} />
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>

      {/* Main Content */}
      <Box
        sx={{
          flexGrow: 1,
          padding: "16px",
          backgroundColor: "#e0e0e0",
          marginLeft: drawerOpen ? "250px" : "0px", // Pomak sadržaja udesno kad je izbornik otvoren
          transition: "margin-left 0.3s ease", // Glatki prijelaz kod pomicanja
        }}
      >
        <Typography
          variant="h4"
          style={{
            textAlign: "center",
            color: "purple",
            fontFamily: "'Dancing Script', cursive",
            marginBottom: "20px",
          }}
        >
          Povijest Svadbi
        </Typography>

        {weddings.map((wedding, index) => (
          <Box
            key={index}
            sx={{
              width: "80%", // Širina boxova
              margin: "20px auto", // Centriraj boxove i dodaj razmak između njih
              backgroundColor: "white",
              borderRadius: "8px", // Zaobljeni rubovi
              boxShadow: "0px 4px 6px rgba(0, 0, 0, 0.1)", // Lagana sjena
            }}
          >
            <Accordion>
              <AccordionSummary expandIcon={<ExpandMoreIcon />}>
                <Typography sx={{ fontWeight: "bold" }}>{wedding.title}</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <Typography>{wedding.content}</Typography>
              </AccordionDetails>
            </Accordion>
          </Box>
        ))}
      </Box>

      {/* Footer */}
      <Box
        sx={{
          backgroundColor: "purple",
          color: "white",
          padding: "10px",
          textAlign: "center", // Poravnanje u centar
          position: "relative", // Drži footer na dnu bez preklapanja
        }}
      >
        <Typography variant="body1" style={{ fontSize: "12px" }}>
          Grupa: PI05/2024
        </Typography>
      </Box>
    </div>
  );
}

export default PovijestSvadbi;
