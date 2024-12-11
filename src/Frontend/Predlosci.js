import React, { useState } from "react";

function Predlosci({ title, items }) {
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);

  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
  };

  return (
    <div className="dropdown-group">
      <div className="dropdown-header" onClick={toggleDropdown}>
        <h3>{title}</h3>
        <span className={`arrow ${isDropdownOpen ? "up" : "down"}`}></span>
      </div>
      {isDropdownOpen && (
        <ul className="dropdown-list">
          {items.map((item, index) => (
            <li key={index}>{item}</li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Predlosci;
