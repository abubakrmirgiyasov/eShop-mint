import React, { useState } from "react";
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
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import Select from "react-select";

const AddressesAction = (props) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [country, setCountry] = useState(null);

  const countries = [
    { label: "Россия", value: "1" },
    { label: "Казахстан", value: "2" },
  ];

  const handleSubmit = (e) => {
    setIsLoading(true);

    const address = {
      id: props.address?.id,
      fullAddress: e.target.address.value,
      country: country,
      city: e.target.city.value,
      zipCode: e.target.zipCode.value,
      description: e.target.description.value,
      userId: props.userId,
    };

    if (!!props.isEdit) {
      fetchWrapper
        .put("api/user/updateuseraddress", address)
        .then((response) => {
          setIsLoading(false);
          props.toggle();
          props.setUpdatedAdress(address);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    } else {
      fetchWrapper
        .post("api/user/adduseraddress", address)
        .then((response) => {
          setIsLoading(false);
          props.toggle();
          props.setNewAddress(response);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    }
  };

  const handleChange = (e) => {
    setCountry(e.label);
  };

  return (
    <React.Fragment>
      <Modal
        isOpen={props.isOpen}
        toggle={props.toggle}
        className={"border-0"}
        modalClassName={"modal-xxl fade zoomIn"}
      >
        {error ? <Error message={error.message} /> : null}
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={props.toggle}
          style={{ borderBottom: "1px" }}
        >
          {!!props.isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className={"modal-body"}>
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              handleSubmit(e);
              return false;
            }}
          >
            <Row>
              <Col lg={12} className={"mb-3"}>
                <Label className={"form-label"} htmlFor={"country"}>
                  Страна
                </Label>
                <Select
                  type={"text"}
                  id={"country"}
                  name={"country"}
                  defaultValue={props.address?.country}
                  options={countries}
                  onChange={handleChange}
                />
                {!country ? (
                  <div className={"text-danger mt-1"}>Выберете страну</div>
                ) : null}
              </Col>
              <Col lg={6}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"city"}>
                    Город
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Введите ваш город"}
                    id={"city"}
                    name={"city"}
                    defaultValue={props.address?.city}
                    required={true}
                  />
                </div>
              </Col>
              <Col lg={6}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"zipCode"}>
                    Почтовый индекс
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Ваш почтовый индекс"}
                    id={"zipCode"}
                    name={"zipCode"}
                    defaultValue={props.address?.zipCode}
                    required={true}
                  />
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"address"}>
                    Адрес
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Введите ваш адрес"}
                    id={"address"}
                    name={"address"}
                    defaultValue={props.address?.address}
                    required={true}
                  />
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"description"}>
                    Описание
                  </Label>
                  <textarea
                    className={"form-control"}
                    placeholder={"Дополнительные сведения"}
                    id={"description"}
                    name={"description"}
                    defaultValue={props.address?.description}
                  ></textarea>
                </div>
              </Col>
              <div className={"d-flex justify-content-end align-items-center"}>
                <Button
                  type={"button"}
                  color={"danger"}
                  className={"me-3"}
                  onClick={props.toggle}
                >
                  <i className={"ri-close-line"}></i> Отмена
                </Button>
                <Button type={"submit"} color={"success"} disabled={isLoading}>
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : null}
                  <i className={"ri-check-double-fill"}></i> Сохранить
                </Button>
              </div>
            </Row>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default AddressesAction;
