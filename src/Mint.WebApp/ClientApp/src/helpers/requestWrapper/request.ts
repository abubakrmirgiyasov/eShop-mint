import { ApiConfiguration } from "./types";
import Axios, { AxiosInstance, AxiosRequestConfig } from "axios";
import { BASE_API_URL } from "../../constants/constants";
import { handleServiceError } from "./serviceErrors";

export interface IRequest {
  get<TResponse>(path: string): Promise<TResponse>;
  post<TRequest, TResponse>(
    path: string,
    object: TRequest,
    config?: AxiosRequestConfig
  ): Promise<TResponse>;
  put<TRequest, TResponse>(path: string, object: TRequest): Promise<TResponse>;
  delete<TResponse>(path: string): Promise<TResponse>;
}

export default class Request implements IRequest {
  private _client: AxiosInstance;

  protected createAxiosClient(
    apiConfiguration: ApiConfiguration
  ): AxiosInstance {
    return Axios.create({
      baseURL: BASE_API_URL,
      responseType: "json" as const,
      headers: {
        "Content-Type": "application/json",
        ...(apiConfiguration.accessToken && {
          Authorization: `Bearer ${apiConfiguration.accessToken}`,
        }),
      },
      timeout: 10 * 1000,
    });
  }

  constructor(apiConfiguration: ApiConfiguration) {
    this._client = this.createAxiosClient(apiConfiguration);
  }

  async get<TResponse>(path: string): Promise<TResponse> {
    try {
      const response = await this._client.get<TResponse>(path);
      return response.data;
    } catch (error) {
      console.log(error);
      handleServiceError(error);
    }
    return {} as TResponse;
  }

  async post<TRequest, TResponse>(
    path: string,
    payload: TRequest,
    config?: AxiosRequestConfig
  ): Promise<TResponse> {
    try {
      const response = config
        ? await this._client.post<TResponse>(path, payload, config)
        : await this._client.post<TResponse>(path, payload);

      return response.data;
    } catch (error) {
      throw error;
    }
  }

  async put<TRequest, TResponse>(
    path: string,
    payload: TRequest
  ): Promise<TResponse> {
    try {
      const response = await this._client.put<TResponse>(path, payload);
      return response.data;
    } catch (error) {
      console.log(error);
      handleServiceError(error);
    }
    return {} as TResponse;
  }

  async delete<TResponse>(path: string): Promise<TResponse> {
    try {
      const response = await this._client.delete<TResponse>(path);
      return response.data;
    } catch (error) {
      console.log(error);
      handleServiceError(error);
    }
    return {} as TResponse;
  }
}
