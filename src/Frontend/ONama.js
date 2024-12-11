import React, { useState } from "react";
import {
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
import { useNavigate } from "react-router-dom";

function ONama() {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const navigate = useNavigate();

  const menuItems = [
    { text: "Početna", icon: <HomeIcon />, action: () => navigate("/") },
    { text: "Povijest vjenčanja", icon: <ArchiveIcon />, action: () => navigate("/povijest-svadbi") },
    { text: "O nama", icon: <InfoIcon />, action: () => navigate("/onama") },
  ];

  const AboutUs = () => (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "flex-start",
        height: "100vh",
        backgroundColor: "#f3f3f3",
        paddingTop: "20px",
      }}
    >
      <Typography
        variant="h4"
        sx={{
          color: "purple",
          fontFamily: "'Dancing Script', cursive",
          marginBottom: "16px",
        }}
      >
        O nama
      </Typography>
      <hr
        style={{
          width: "80%",
          border: "1px solid purple",
          marginBottom: "16px",
        }}
      />
      <Typography
        variant="h5"
        sx={{
          color: "purple",
          fontFamily: "'Dancing Script', cursive",
          marginBottom: "16px",
        }}
      >
        Grupa: PI05
      </Typography>
      <Typography
        variant="h6"
        sx={{
          color: "black",
          textAlign: "center",
          marginBottom: "16px",
          fontStyle: "italic",
        }}
      >
        Članovi tima:
      </Typography>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          gap: "8px",
          padding: "16px",
          backgroundColor: "white",
          borderRadius: "8px",
          boxShadow: "0 4px 6px rgba(0, 0, 0, 0.1)",
        }}
      >
        <Typography variant="body1" sx={{ fontWeight: "bold", color: "purple" }}>
          Stjepan Radić
        </Typography>
        <Typography variant="body1" sx={{ fontWeight: "bold", color: "purple" }}>
          Ante Pavlović
        </Typography>
        <Typography variant="body1" sx={{ fontWeight: "bold", color: "purple" }}>
          Anđela Marinović
        </Typography>
        <Typography variant="body1" sx={{ fontWeight: "bold", color: "purple" }}>
          Leonardo Misir
        </Typography>
        <Typography variant="body1" sx={{ fontWeight: "bold", color: "purple" }}>
          Zvonimir Kožul
        </Typography>
      </Box>
    </Box>
  );

  return (
    <div style={{ display: "flex", flexDirection: "column", height: "100vh", backgroundColor: "#f3f3f3" }}>
      {/* Drawer Button */}
      <IconButton
        onClick={() => setDrawerOpen(true)}
        style={{ position: "absolute", top: 16, left: 16, color: "purple" }}
      >
        <MenuIcon fontSize="large" />
      </IconButton>

      {/* Drawer */}
      <Drawer anchor="left" open={drawerOpen} onClose={() => setDrawerOpen(false)}>
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
                onClick={() => {
                  setDrawerOpen(false);
                  item.action();
                }}
                sx={{
                  cursor: "pointer",
                  "&:hover": { backgroundColor: "rgba(255, 255, 255, 0.2)" },
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
      <AboutUs />

      {/* Footer */}
      <Box
        sx={{
          backgroundColor: "purple",
          color: "white",
          padding: "10px",
          textAlign: "center",
          position: "fixed",
          bottom: 0,
          width: "100%",
        }}
      >
        <Typography variant="body1" style={{ fontSize: "12px" }}>
          Grupa: PI05/2024
        </Typography>
      </Box>
    </div>
  );
}

export default ONama;
