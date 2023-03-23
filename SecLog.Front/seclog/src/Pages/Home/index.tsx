import React, { useState } from "react";
import { CssBaseline } from "@mui/material";
import { Box, TextField, Button, Snackbar, Alert } from "@mui/material";
import Container from "@mui/material/Container";
import {
  getItemLogByDescription,
  getItemLogByInterval,
  getItemLogByLimit,
  importLog,
} from "../../Services/logServices";
import { format } from "date-fns";

function Home() {
  const [description, setDescription] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [logs, setLogs] = useState([]);
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const [type, setType] = useState<"success" | "error" | "info">("success");

  function handleChangeStartDate(date: string) {
    setStartDate(date);
  }

  function handleChangeEndDate(date: string) {
    setEndDate(date);
  }

  function handleChangeDescription(description: string) {
    setStartDate("");
    setEndDate("");
    setDescription(description);
  }

  function handleMessage(message: string, type: "success" | "error" | "info") {
    setOpen(true);
    setMessage(message);
    setType(type);
  }

  function handleClose(event: React.SyntheticEvent | Event, reason?: string) {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
    setMessage("");
  }

  async function handleSubmitLog() {
    try {
      handleMessage("Loading", "info");
      const response = await importLog();
      handleMessage(response.data, "info");
    } catch (error) {
      handleMessage("Error", "error");
    }
  }

  async function handleSubmitLimit() {
    try {
      handleMessage("Loading", "info");
      let response;
      if (startDate && endDate) {
        console.log(format(new Date(startDate), "yyyy-MM-dd HH:mm:ss"));
        response = await getItemLogByInterval(
          format(new Date(startDate), "yyyy-MM-dd HH:mm:ss"),
          format(new Date(endDate), "yyyy-MM-dd HH:mm:ss"),
          100
        );
      } else if (description) {
        response = await getItemLogByDescription(description, 100);
      } else {
        response = await getItemLogByLimit(100);
      }
      handleMessage("Success", "success");
      setLogs(response.data);
    } catch (error) {
      handleMessage("Error", "error");
    }
  }

  return (
    <>
      <CssBaseline />
      <Container>
        <Box sx={{ height: "100vh", mt: 2 }}>
          <Box
            display="flex"
            sx={{ justifyContent: "center", alignItems: "center" }}
          >
            <Button type="button" onClick={handleSubmitLog}>
              Import Logs
            </Button>
          </Box>
          <Box display="flex" component="form" sx={{ flexDirection: "row" }}>
            <TextField
              fullWidth
              value={startDate}
              label="Start Date"
              onChange={(event) => handleChangeStartDate(event.target.value)}
              type="datetime-local"
              variant="filled"
              InputLabelProps={{
                shrink: true,
              }}
            />
            <TextField
              fullWidth
              value={endDate}
              label="End Date"
              onChange={(event) => handleChangeEndDate(event.target.value)}
              type="datetime-local"
              variant="filled"
              InputLabelProps={{
                shrink: true,
              }}
            />
            <TextField
              fullWidth
              label="Description"
              value={description}
              onChange={(event) => handleChangeDescription(event.target.value)}
              type="text"
              variant="filled"
            />
            <Button type="button" onClick={handleSubmitLimit}>
              {" "}
              Search{" "}
            </Button>
          </Box>

          <Box component="ul" display="flex" sx={{ flexDirection: "column" }}>
            {logs?.map((log, i) => (
              <li key={i}>{JSON.stringify(log)}</li>
            ))}
          </Box>
        </Box>
      </Container>
      <Snackbar
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        open={open}
        autoHideDuration={5000}
        onClose={handleClose}
      >
        <Alert onClose={handleClose} severity={type} sx={{ width: "100%" }}>
          {message}
        </Alert>
      </Snackbar>
    </>
  );
}

export default Home;
