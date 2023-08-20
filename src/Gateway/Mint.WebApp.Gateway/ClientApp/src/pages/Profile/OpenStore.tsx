import React, { FC, useState } from "react";
import { IUserStore } from "../../services/types/IUser";
import { Col, Collapse, Row, Spinner } from "reactstrap";
import Popover from "../../components/Common/Popover";
import Select from "react-select";
import PhoneInput from "react-phone-input-2";
import SingleImage from "../../components/Dropzone/SingleImage";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

interface IOpenStore {
  handleNewStore: IUserStore;
}

const OpenStore: FC<IOpenStore> = ({ handleNewStore }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isFormOpened, setIsFormOpened] = useState<boolean>(false);
  const [image, setImage] = useState<File[]>([]);

  const toggleForm = () => setIsFormOpened(!isFormOpened);

  const handleImage = (image: File[]) => setImage(image);

  return (
    <React.Fragment>
      <form>
        <div
          className={
            "d-flex justify-content-start align-items-center mt-3 mb-3"
          }
        >
          <button
            type={"button"}
            className={"btn btn-success"}
            onClick={toggleForm}
          >
            <i className={"ri-store-2-line me-2"}></i> Октрыть магазин
          </button>
        </div>
        {!isFormOpened ? (
          <div>
            <h3 className={"mt-3 text-center fs-18 text-muted"}>
              У вас еще нет магазина
            </h3>
            <div className={"d-flex justify-content-center align-items-center"}>
              <lord-icon
                src={"https://cdn.lordicon.com/vaeagfzc.json"}
                trigger={"loop"}
                colors={"primary:#121331,secondary:#08a88a"}
                state={"loop"}
                style={{ width: "250px", height: "250px" }}
              ></lord-icon>
            </div>
          </div>
        ) : (
          <Collapse isOpen={isFormOpened}>
            <Row>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"name"}>
                  Название{" "}
                  <Popover
                    id={"name"}
                    placement={"right"}
                    text={"Здесь вы вводите название вашего магазина."}
                  />
                </label>
                <input
                  type={"text"}
                  id={"name"}
                  className={"form-control"}
                  placeholder={"Введите название магазина"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"url"}>
                  Путь магазина{" "}
                  <Popover
                    id={"url"}
                    placement={"right"}
                    text={
                      "Здесь вы вводите путь до вашего магазина. Например: mystore/"
                    }
                  />
                </label>
                <input
                  type={"text"}
                  id={"url"}
                  className={"form-control"}
                  placeholder={"Введите путь до вашего магазина"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"workHours"}>
                  Часы работы{" "}
                  <Popover id={"workHours"} placement={"right"} text={""} />
                </label>
                <input
                  type={"text"}
                  id={"workHours"}
                  className={"form-control"}
                  placeholder={"Введите путь до вашего магазина"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"email"}>
                  Email <Popover id={"email"} placement={"right"} text={""} />
                </label>
                <input
                  type={"email"}
                  id={"email"}
                  className={"form-control"}
                  placeholder={"Введите путь до вашего магазина"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"phone"}>
                  Телефон <Popover id={"phone"} placement={"right"} text={""} />
                </label>
                <PhoneInput
                  country={"ru"} // language?.name ||
                  value={``} // ${user?.phone}
                  inputClass={"w-100"}
                  // onChange={handlePhoneChange}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"categories"}>
                  Категории
                </label>
                <Select
                  placeholder={"Выберите категории"}
                  options={[]}
                  isMulti
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label me-2"} id={"isOwnStore"}>
                  Свой склад{" "}
                  <Popover id={"isOwnStore"} placement={"right"} text={""} />
                </label>
                <input
                  type={"checkbox"}
                  className={"form-checkbox"}
                  id={"isOwnStore"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"logo"}>
                  Логотип{" "}
                  <Popover
                    id={"logo"}
                    placement={"right"}
                    text={"Поле для логотипа вашего магазина."}
                  />
                </label>
                <SingleImage
                  currentImage={""}
                  name={""}
                  onChange={handleImage}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <label className={"form-label"} id={"addressDescription"}>
                  Описание для адреса{" "}
                  <Popover
                    id={"addressDescription"}
                    placement={"right"}
                    text={"Здесь вы можете описать локацию вашего магазина."}
                  />
                </label>
                <CKEditor
                  editor={ClassicEditor}
                  id="text"
                  onChange={(event, editor) => {}}
                  data={""}
                />
              </Col>
              <Col
                lg={12}
                className={"d-flex justify-content-end align-items-center"}
              >
                <button
                  type={"submit"}
                  className={"btn btn-success"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : (
                    <i className={"ri-check-double-fill me-2"}></i>
                  )}{" "}
                  Создать
                </button>
              </Col>
            </Row>
          </Collapse>
        )}
      </form>
    </React.Fragment>
  );
};

export default OpenStore;
