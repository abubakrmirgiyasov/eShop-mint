import { Colors } from "../../constants/commonList";

export interface INotification {
  message: string;
  type: Colors | string;
}
