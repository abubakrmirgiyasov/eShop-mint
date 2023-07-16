import { ApiConfiguration } from "./requestWrapper/types";
import authHeader from "../services/authentication/authHeader";
import Request from "./requestWrapper/request";

export const fetch = () => {
  const settings = new ApiConfiguration();
  settings.accessToken = authHeader();
  return new Request(settings);
};
