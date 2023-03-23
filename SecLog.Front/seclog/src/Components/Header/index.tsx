import React from "react";
import { AppBar, Box, Toolbar } from "@mui/material";

const Header: React.FC = () => {
  return (
    <Box sx={{ display: "flex" }}>
      <AppBar position="fixed">
        <Toolbar
          sx={{
            pr: "60px",
          }}
        ></Toolbar>
      </AppBar>
    </Box>
  );
};

export default Header;
