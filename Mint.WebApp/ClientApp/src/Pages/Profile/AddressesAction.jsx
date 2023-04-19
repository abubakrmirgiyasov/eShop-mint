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
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";

const AddressesAction = (props) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = (e) => {
    const address = {
      fullAddress: e.target.address.value,
      country: e.target.country.value,
      city: e.target.city.value,
      zipCode: e.target.zipCode.value,
      description: e.target.description,
      userId: props.userId,
    };
    // fetchWrapper.()
  };

  return (
    <React.Fragment>
      <Modal
        isOpen={props.isOpen}
        toggle={props.toggle}
        className="border-0"
        modalClassName="modal-xxl fade zoomIn"
      >
        <ModalHeader
          className="p-3 bg-soft-white border-bottom-dashed"
          toggle={props.toggle}
          style={{ borderBottom: "1px" }}
        >
          {!!props.isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className="modal-body">
          <Form onSubmit={(e) => {
            e.preventDefault();
            handleSubmit(e);
            return false;
          }}>
            <Row>
              <Col lg={12}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="country">
                    Страна
                  </Label>
                  <select
                    type="text"
                    className="form-control"
                    id="country"
                    name="country"
                    defaultValue={props.address?.city}
                  >
                    <option>Выберете страну</option>
                  </select>
                </div>
              </Col>
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="city">
                    Город
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш город"
                    id="city"
                    name="city"
                    defaultValue={props.address?.city}
                  />
                </div>
              </Col>
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="zipCode">
                    Почтовый индекс
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Ваш почтовый индекс"
                    id="zipCode"
                    name="zipCode"
                    defaultValue={props.address?.zipCode}
                  />
                </div>
              </Col>
              <Col lg={12}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="address">
                    Адрес
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш адрес"
                    id="address"
                    name="address"
                    defaultValue={props.address?.address1}
                  />
                </div>
              </Col>
              <Col lg={12}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="description">
                    Описание
                  </Label>
                  <textarea
                    className="form-control"
                    placeholder="Дополнительные сведения"
                    id="description"
                    name="description"
                    defaultValue={props.address?.description}
                  ></textarea>
                </div>
              </Col>
              <div className="d-flex justify-content-end align-items-center">
                <Button
                    type="button"
                    color="danger"
                    className="me-3"
                    onClick={() => {
                        props.toggle();
                    }}
                >
                    <i className="ri-close-line"></i> Отмена
                </Button>
                <Button
                    type="submit"
                    color="success"
                    disabled={false}
                >
                    <i className="ri-check-double-fill"></i> Сохранить
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
