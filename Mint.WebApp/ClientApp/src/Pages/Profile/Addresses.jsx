import React, { useCallback, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Col,
  Row,
  TabPane,
} from "reactstrap";
import AddressesAction from "./AddressesAction";
import DeleteAddress from "./DeleteAddress";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";

const Addresses = ({ activeTab, userId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isModal, setIsModal] = useState(false);
  const [isDeleteModal, setIsDeleteModal] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [address, setAddress] = useState([]);
  const [addresses, setAddresses] = useState([]);

  useEffect(() => {
    if (activeTab === 2) {
      fetchWrapper
        .get("api/user/getuseraddressesbyid/" + userId)
        .then((response) => {
          setAddresses(response);
          setIsLoading(false);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    }
  }, [activeTab, userId]);

  const deleteToggle = useCallback(() => {
    if (isDeleteModal) {
      setIsDeleteModal(false);
    } else {
      setIsDeleteModal(true);
    }
  }, [isDeleteModal]);

  const handleDeleteAddressClick = useCallback(
    (arg) => {
      setAddress({ id: arg.id });
      setIsDeleteModal(true);
      deleteToggle();
    },
    [deleteToggle]
  );

  const actionToggle = useCallback(() => {
    if (isModal) {
      setIsModal(false);
      setAddress(null);
    } else {
      setIsModal(true);
    }
  }, [isModal]);

  const handleChangeAddressClick = useCallback(
    (arg) => {
      setAddress({
        id: arg.id,
        address: arg.fullAddress,
        zipCode: arg.zipCode,
        country: arg.country,
        city: arg.city,
        description: arg.description,
      });

      setIsEdit(true);
      actionToggle();
    },
    [actionToggle]
  );

  function setNewAddress(newAdress) {
    setAddresses([...addresses, newAdress]);
  }

  function setUpdatedAdress(updatedAdress) {
    console.log(updatedAdress);
  }

  function setAddressAfterDeleting(id) {
    const newList = addresses.filter((x) => x.id !== id);
    setAddresses(newList);
  }

  return (
    <React.Fragment>
      <TabPane tabId={2}>
        {error ? <Error message={error} /> : null}
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <Card>
            <CardBody>
              <div
                className={
                  "d-flex justify-content-start align-items-center mb-3"
                }
              >
                <h2>Адреса</h2>
              </div>
              <Row>
                <Col md={12} lg={12}>
                  <div
                    className={
                      "d-flex justify-content-start align-items-center mb-3"
                    }
                  >
                    <Button
                      className={"btn btn-primary"}
                      color={"primary"}
                      onClick={() => {
                        setIsEdit(false);
                        actionToggle();
                      }}
                    >
                      <i className={"ri-add-line"}></i> Добавить новый
                    </Button>
                  </div>
                  <Row>
                    {addresses.length !== 0 ? (
                      addresses.map((item, key) => (
                        <Col sm={8} key={key} className={"w-50"}>
                          <Card>
                            <CardBody className={"bg-light"}>
                              <h3>{item.fullName}</h3>
                              <h5 className={"text-muted fs-6"}>
                                Email: {item.email}
                                <br />
                                Телеон: {item.phone}
                              </h5>
                              <h5 className={"text-muted fs-6"}>
                                ФИО: {item.fullName}
                              </h5>
                              <h5 className={"text-muted fs-6"}>
                                Компания: John Smith LLC
                              </h5>
                              <h5 className={"text-muted fs-6"}>
                                Адрес: {item.fullAddress}
                              </h5>
                              <h5 className={"text-muted fs-6"}>
                                Город: {item.city} Поч. Индекс: {item.zipCode}
                              </h5>
                              <h5 className={"text-muted fs-6"}>
                                Страна: {item.country}
                              </h5>
                            </CardBody>
                            <CardFooter
                              className={
                                "d-flex justify-content-end align-items-center bg-light"
                              }
                            >
                              <Button
                                className={"btn btn-success me-3"}
                                onClick={() =>
                                  handleChangeAddressClick({
                                    id: item.id,
                                    fullAddress: item.fullAddress,
                                    zipCode: item.zipCode,
                                    country: item.country,
                                    city: item.city,
                                    description: item.description,
                                  })
                                }
                              >
                                <i className={"ri-edit-line"}></i> Изменить
                              </Button>
                              <Button
                                className={"btn btn-danger"}
                                onClick={() =>
                                  handleDeleteAddressClick({ id: item.id })
                                }
                              >
                                <i className={"ri-delete-bin-7-line"}></i>{" "}
                                Удалить
                              </Button>
                            </CardFooter>
                          </Card>
                        </Col>
                      ))
                    ) : (
                      <Col>
                        <h3 className={"mt-3 text-center fs-18"}>
                          Вы пока не добавляли адрес!
                        </h3>
                      </Col>
                    )}
                  </Row>
                </Col>
              </Row>
            </CardBody>
          </Card>
        )}
      </TabPane>
      <AddressesAction
        userId={userId}
        isOpen={isModal}
        toggle={actionToggle}
        address={address}
        isEdit={isEdit}
        setNewAddress={setNewAddress}
        setUpdatedAdress={setUpdatedAdress}
      />
      <DeleteAddress
        isOpen={isDeleteModal}
        toggle={deleteToggle}
        id={address?.id}
        setAddressAfterDeleting={setAddressAfterDeleting}
      />
    </React.Fragment>
  );
};

export default Addresses;
