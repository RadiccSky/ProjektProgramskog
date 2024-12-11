import React, { useState } from "react";
import {
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Box,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Button,
  FormControlLabel,
  Checkbox,
  Drawer,
  IconButton,
  Typography
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import HomeIcon from "@mui/icons-material/Home";
import InfoIcon from "@mui/icons-material/Info";
import ArchiveIcon from "@mui/icons-material/Archive";
import "@fontsource/dancing-script";
import { useNavigate } from "react-router-dom";

function NovoVjencanje() {
  const [form, setForm] = useState({
    naziv: "",
    lokacija: "",
    hrana: "",
    glazbenici: "",
    playlist: [],
    gosti: "",
  });

  const [ukupno, setUkupno] = useState(0);
  const [cijenaStolica, setCijenaStolica] = useState(0);
  const [drawerOpen, setDrawerOpen] = useState(false);
  const navigate = useNavigate();

  const toggleDrawer = (open) => () => {
    setDrawerOpen(open);
  };

  const handleChange = (field) => (event) => {
    if (field === "playlist") {
      const selected = event.target.value;
      setForm((prev) => ({
        ...prev,
        playlist: prev.playlist.includes(selected)
          ? prev.playlist.filter((item) => item !== selected)
          : [...prev.playlist, selected],
      }));
    } else {
      setForm({ ...form, [field]: event.target.value });
      if (field === "lokacija") {
        const cijeneStolica = { "Sala Viva": 60, "Sala Jabuka": 50, "Restoran Domano": 40 };
        setCijenaStolica(cijeneStolica[event.target.value] || 0);
      }
    }
  };

  const handleSpremi = () => {
    const cijene = {
      lokacija: { "Sala Viva": 5000, "Sala Jabuka": 4000, "Restoran Domano": 3500 },
      hrana: {
        "Predjelo, Glavno jelo, Desert": 300,
        "Predjelo, Glavno jelo": 200,
        "Glavno jelo, Desert": 250,
        "Glavno jelo": 150,
      },
      glazbenici: {
        "Grupa Sinergija": 5000,
        "Antoniette čerkez": 7000,
        "Grše": 8000,
      },
    };

    // Izračun ukupne cijene
    const ukupnoCijena =
      (cijene.lokacija[form.lokacija] || 0) +
      (cijene.hrana[form.hrana] || 0) +
      (cijene.glazbenici[form.glazbenici] || 0) +
      (cijenaStolica * (parseInt(form.gosti) || 0));

    setUkupno(ukupnoCijena); // Postavljanje ukupne cijene
  };

  const handleOdbaci = () => {
    setForm({ naziv: "", lokacija: "", hrana: "", glazbenici: "", playlist: [], gosti: "" });
    setUkupno(0);
    setCijenaStolica(0);
  };

  const handlePotvrdi = () => {
    alert("Vjenčanje spremljeno!");
    handleOdbaci();
  };

  const menuItems = [
    { text: "Početna", icon: <HomeIcon />, action: () => navigate("/") },
    { text: "Povijest vjenčanja", icon: <ArchiveIcon />, action: () => navigate("/povijest-svadbi") },
    { text: "O nama", icon: <InfoIcon />, action: () => alert("O nama!") },
  ];

  return (
    <div style={{ display: "flex", height: "100vh", flexDirection: "column" }}>
      <IconButton
        onClick={toggleDrawer(true)}
        style={{ position: "absolute", top: 16, left: 16, color: "purple" }}
      >
        <MenuIcon fontSize="large" />
      </IconButton>

      {/* Drawer Component */}
      <Drawer anchor="left" open={drawerOpen} onClose={toggleDrawer(false)}>
        <Box sx={{ width: 250, height: "100%", backgroundColor: "purple", color: "white", padding: "16px" }}>
          <Typography variant="h5" style={{ marginBottom: "16px", textAlign: "center" }}>
            Izbornik
          </Typography>
          <List>
            {menuItems.map((item, index) => (
              <ListItem button key={index} onClick={item.action} sx={{ cursor: "pointer", "&:hover": { backgroundColor: "rgba(255, 255, 255, 0.2)" } }}>
                <ListItemIcon style={{ color: "white" }}>{item.icon}</ListItemIcon>
                <ListItemText primary={item.text} style={{ color: "white" }} />
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>

      {/* Main Content */}
      <Box sx={{ flexGrow: 1, padding: 3, marginLeft: "80px",  display: "flex" }}>
        <Box sx={{ flex: 6 }}>
          <Typography
            variant="h4"
            sx={{
              fontFamily: "'Dancing Script', cursive",
              fontWeight: "bold",
              textAlign: "center",
              color: "purple",
              borderBottom: "2px solid purple",
              paddingBottom: 1,
              marginBottom: 4,
            }}
          >
            Kreiranje planera za vjenčanje
          </Typography>

          <Box sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <TextField
              label="Naziv vjenčanja"
              variant="outlined"
              value={form.naziv}
              onChange={handleChange("naziv")}
              sx={{
                backgroundColor: "white",
                borderRadius: 1,
                width: "40%",
              }}
            />
            <FormControl sx={{ backgroundColor: "white", borderRadius: 5, width: "40%" }}>
              <InputLabel sx={{ color: "purple" }}>Lokacija</InputLabel>
              <Select value={form.lokacija} onChange={handleChange("lokacija")}>
                <MenuItem value="Sala Viva">Sala Viva</MenuItem>
                <MenuItem value="Sala Jabuka">Sala Jabuka</MenuItem>
                <MenuItem value="Restoran Domano">Restoran Domano</MenuItem>
              </Select>
            </FormControl>
            <FormControl sx={{ backgroundColor: "white", borderRadius: 1, width: "40%" }}>
              <InputLabel sx={{ color: "purple" }}>Hrana</InputLabel>
              <Select value={form.hrana} onChange={handleChange("hrana")}>
                <MenuItem value="Predjelo, Glavno jelo, Desert">Predjelo, Glavno jelo, Desert</MenuItem>
                <MenuItem value="Predjelo, Glavno jelo">Predjelo, Glavno jelo</MenuItem>
                <MenuItem value="Glavno jelo, Desert">Glavno jelo, Desert</MenuItem>
                <MenuItem value="Glavno jelo">Glavno jelo</MenuItem>
              </Select>
            </FormControl>
            <FormControl sx={{ backgroundColor: "white", borderRadius: 1, width: "40%" }}>
              <InputLabel sx={{ color: "purple" }}>Glazbenici</InputLabel>
              <Select value={form.glazbenici} onChange={handleChange("glazbenici")}>
                <MenuItem value="Grupa Sinergija">Grupa Sinergija</MenuItem>
                <MenuItem value="Antoniette čerkez">Antoniette čerkez</MenuItem>
                <MenuItem value="Grše">Grše</MenuItem>
              </Select>
            </FormControl>

            {/* Playlista */}
            <Box sx={{ display: "flex", flexDirection: "column", gap: 0, marginTop: 1, width: "40%" }}>
              <Typography sx={{ color: "purple" }}>Playlista:</Typography>
              <FormControlLabel
                control={<Checkbox value="Domaće" checked={form.playlist.includes("Domaće")} onChange={handleChange("playlist")} />}
                label="Domaće"
                sx={{ margin: 0 }} 
              />
              <FormControlLabel
                control={<Checkbox value="Strano" checked={form.playlist.includes("Strano")} onChange={handleChange("playlist")} />}
                label="Strano"
                sx={{ margin: 0 }} 
              />
              <FormControlLabel
                control={<Checkbox value="Narodno" checked={form.playlist.includes("Narodno")} onChange={handleChange("playlist")} />}
                label="Narodno"
                sx={{ margin: 0 }} 
              />
            </Box>

            <TextField
              label="Broj Gostiju"
              variant="outlined"
              value={form.gosti}
              onChange={handleChange("gosti")}
              sx={{
                backgroundColor: "white",
                borderRadius: 1,
                width: "40%",
              }}
            />
            <Button
              variant="contained"
              onClick={handleSpremi}
              sx={{
                backgroundColor: "purple",
                color: "white",
                borderRadius: 2,
                width: "20%",
                marginTop: 1,
                marginBottom: 1,
              }}
            >
              Spremi
            </Button>
          </Box>
        </Box>

        {/* Right Sidebar */}
        <Box sx={{
          flex: 4,
          paddingLeft: 2,
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          border: "2px solid purple",
          borderRadius: "8px",
          padding: 5,
          backgroundColor: "white",
          boxShadow: "0px 4px 10px rgba(0, 0, 0, 0.2)",
          width: "20%",
          height: "auto",
          minHeight: "80px",
          maxHeight: "500px",
          top: "100px",
          position: "relative",
          marginTop: 1,
        }}>
          <Typography
            variant="h6"
            sx={{
              color: "purple",
              marginBottom: 2,
              fontWeight: "bold",
              textAlign: "center",
            }}
          >
            Odabrane opcije:
          </Typography>
          {form.naziv && <Typography>Naziv vjenčanja: {form.naziv}</Typography>}
          {form.lokacija && (
            <Typography>
              Lokacija: {form.lokacija} (Cijena stolica: {cijenaStolica} KM)
            </Typography>
          )}
          {form.hrana && (
            <Typography>
              Hrana: {form.hrana} (Cijena:{" "}
              {form.hrana === "Predjelo, Glavno jelo, Desert"
                ? 300
                : form.hrana === "Predjelo, Glavno jelo"
                ? 200
                : form.hrana === "Glavno jelo, Desert"
                ? 250
                : 150}{" "}
              KM)
            </Typography>
          )}
          {form.glazbenici && (
            <Typography>
              Glazbenici: {form.glazbenici} (Cijena:{" "}
              {form.glazbenici === "Grupa Sinergija"
                ? 5000
                : form.glazbenici === "Antoniette čerkez"
                ? 7000
                : 8000}{" "}
              KM)
            </Typography>
          )}
          {form.playlist.length > 0 && (
            <Typography>Playlist: {form.playlist.join(", ")}</Typography>
          )}
          {form.gosti && <Typography>Broj gostiju: {form.gosti}</Typography>}
          <Typography sx={{ color: "purple", fontWeight: "bold", marginTop: 2 }}>
            Ukupna cijena: {ukupno} KM
          </Typography>

          <Button
            variant="contained"
            onClick={handlePotvrdi}
            sx={{
              backgroundColor: "purple",
              color: "white",
              borderRadius: 2,
              width: "100%",
              marginTop: 2,
            }}
          >
            Potvrdi
          </Button>
        </Box>
      </Box>
      <Box sx={{ padding: 2, backgroundColor: "purple", color: "white", textAlign: "center", fontSize: "12px" }}>
        <Typography variant="body1">Grupa: PI05/2024</Typography>
      </Box>
    </div>
  );
}

export default NovoVjencanje;
