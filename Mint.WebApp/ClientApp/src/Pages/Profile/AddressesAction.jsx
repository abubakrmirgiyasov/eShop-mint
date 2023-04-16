import React from "react";
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
import Devider from "../../components/Devider/Devider";

const AddressesAction = (props) => {
  console.log(props.address);
  return (
    <React.Fragment>
      <Modal
        isOpen={props.isOpen}
        toggle={props.toggle}
        className="border-0"
        modalClassName="modal-xl fade zoomIn"
      >
        <ModalHeader
          className="p-3 bg-soft-white border-bottom-dashed"
          toggle={props.toggle}
          style={{ borderBottom: "1px" }}
        >
          {!!props.isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className="modal-body">
          <Form>
            <Row>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="firstName">
                    Фамилия
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите фамилию"
                    id="firstName"
                    name="firstName"
                    defaultValue={props.address?.firstName}
                  />
                </div>
              </Col>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="secondName">
                    Имя
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите имя"
                    id="secondName"
                    name="secondName"
                    defaultValue={props.address?.secondName}
                  />
                </div>
              </Col>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="lastName">
                    Отчество
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите отчество"
                    id="lastName"
                    name="lastName"
                    defaultValue={props.address?.lastName}
                  />
                </div>
              </Col>
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="email">
                    Email
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите адрес электроной почты"
                    id="email"
                    name="email"
                    defaultValue={props.address?.email}
                  />
                </div>
              </Col>
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="phone">
                    Телефон
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите телефон"
                    id="phone"
                    name="phone"
                    defaultValue={props.address?.phone}
                  />
                </div>
              </Col>
              <Devider />
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="address1">
                    Адрес 1
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш адрес 1"
                    id="address1"
                    name="address1"
                    defaultValue={props.address?.address1}
                  />
                </div>
              </Col>
              <Col lg={6}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="address2">
                    Адрес 2
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш адрес 2"
                    id="address2"
                    name="address2"
                    defaultValue={props.address?.address2}
                  />
                </div>
              </Col>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="city">
                    Город
                  </Label>
                  <select
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш адрес город"
                    id="city"
                    name="city"
                    defaultValue={props.address?.city}
                  />
                </div>
              </Col>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="city">
                    Город
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш адрес город"
                    id="city"
                    name="city"
                    defaultValue={props.address?.city}
                  />
                </div>
              </Col>
              <Col lg={4}>
                <div className="form-group mb-3">
                  <Label className="form-label" htmlFor="zipCode">
                    Почтовый индекс
                  </Label>
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Введите ваш почтовый индекс"
                    id="zipCode"
                    name="zipCode"
                    defaultValue={props.address?.zipCode}
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
