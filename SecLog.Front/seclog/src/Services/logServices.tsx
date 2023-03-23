import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7267/",
});

const importLog = async () => {
  return await api.post("Log/importlog");
};

const getItemLogByLimit = async (limit: number) => {
  return await api.get(`Log/GetItemsLogByLimit/${limit}`);
};

const getItemLogByInterval = async (
  startDate: string,
  endDate: string,
  limit: number
) => {
  return await api.get(
    `Log/GetItemsByInterval/${startDate}/${endDate}/${limit}`
  );
};

const getItemLogByDescription = async (description: string, limit: number) => {
  return await api.get(`Log/GetItemsByDescription/${description}/${limit}`);
};

export {
  importLog,
  getItemLogByLimit,
  getItemLogByInterval,
  getItemLogByDescription,
};

export default api;
