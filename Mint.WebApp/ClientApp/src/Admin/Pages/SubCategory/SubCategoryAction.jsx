import React, { useCallback, useEffect, useState } from "react";
import {
  Button,
  Col,
  Form,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalHeader,
  Row,
  Spinner,
} from "reactstrap";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import IconMenu from "../../../components/IconMneu/IconMenu";

const SubCategoryAction = ({
  isOpen,
  toggle,
  newData,
  updateData,
  handleUpdateData,
}) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isOpenIconMenu, setIsOpenIconMenu] = useState(false);
  const [ico, setIco] = useState("");

  useEffect(() => {
    setIco(updateData?.ico);
  }, [updateData?.ico]);

  const handleSubmit = (e) => {
    setIsLoading(true);

    const data = {
      id: updateData ? updateData.id : null,
      name: e.target.name.value,
      ico: e.target.ico.value,
      displayOrder: e.target.displayOrder.value,
    };

    if (updateData) {
      fetchWrapper
        .put("api/subcategory/updatesubcategory", data)
        .then((response) => {
          setIsLoading(false);
          handleUpdateData(data);
          toggle();
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    } else {
      fetchWrapper
        .post("api/subcategory/addsubcategory", data)
        .then((response) => {
          setIsLoading(false);
          newData(response);
          toggle();
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    }
  };

  const iconMenuToggle = useCallback(() => {
    if (isOpenIconMenu) {
      setIsOpenIconMenu(false);
    } else {
      setIsOpenIconMenu(true);
    }
  }, [isOpenIconMenu]);

  function handleSetIconClick(item) {
    setIco(item);
  }

  function onToggle() {
    setIco("");
    toggle();
  }

  return (
    <React.Fragment>
      <Modal
        isOpen={isOpen}
        toggle={onToggle}
        className={"border-0"}
        modalClassName={"modal-xxl fade zoomIn"}
        centered={true}
      >
        {error ? <Error message={error} /> : null}
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={onToggle}
          style={{ borderBottom: "1px" }}
        >
          {updateData ? "Изменить" : "Добавить"}
        </ModalHeader>
        <ModalBody>
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              handleSubmit(e);
              return false;
            }}
          >
            <Row>
              <Col lg={12} className={"mb-3"}>
                <div className={"form-group"}>
                  <Label className={"form-label"} htmlFor={"displayOrder"}>
                    Сортировать по
                  </Label>
                  <Input
                    type={"number"}
                    className={"form-control"}
                    placeholder={"Сортировать по"}
                    name={"displayOrder"}
                    id={"displayOrder"}
                    defaultValue={updateData?.displayOrder || ""}
                  />
                </div>
              </Col>
              <Col lg={12} className={"mb-3"}>
                <div className={"form-group"}>
                  <Label className={"form-label"} htmlFor={"name"}>
                    Название
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Введите название"}
                    name={"name"}
                    id={"name"}
                    defaultValue={updateData?.name || ""}
                    required={true}
                  />
                </div>
              </Col>
              <Col lg={12}>
                <Row>
                  <Col lg={6} className={"mb-3"}>
                    <Label className={"form-label"} htmlFor={"ico"}>
                      Иконка
                    </Label>
                    <Input
                      type={"text"}
                      className={"form-control"}
                      placeholder={"Введите название"}
                      name={"ico"}
                      id={"ico"}
                      defaultValue={ico}
                      required={true}
                    />
                  </Col>
                  <Col
                    lg={6}
                    className={
                      "d-flex justify-content-center align-items-center mb-3 col-lg-6 pt-4"
                    }
                  >
                    <Button
                      type={"button"}
                      className={"btn btn-danger"}
                      color={"danger"}
                      onClick={iconMenuToggle}
                    >
                      <i className={"ri ri-add-line"}></i>
                      Выбрать иконку
                    </Button>
                  </Col>
                </Row>
                <div className={"form-group"}></div>
              </Col>

              <Col
                lg={12}
                className={"d-flex justify-content-end align-items-center"}
              >
                <Button
                  type={"submit"}
                  className={"btn btn-primary"}
                  color={"primary"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className="me-2">
                      Loading...
                    </Spinner>
                  ) : null}
                  Сохранить
                </Button>
              </Col>
            </Row>
          </Form>
        </ModalBody>
      </Modal>
      <IconMenu
        isOpen={isOpenIconMenu}
        toggle={iconMenuToggle}
        activeIco={ico}
        handleSetIconClick={handleSetIconClick}
      />
    </React.Fragment>
  );
};

export default SubCategoryAction;
