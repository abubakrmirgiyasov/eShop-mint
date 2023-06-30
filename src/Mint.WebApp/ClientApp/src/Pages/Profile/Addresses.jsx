import React, { useCallback, useState, useEffect } from "react";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Col,
  Row,
  Spinner,
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

  function setNewAddress(newAddress) {
    setAddresses([...addresses, newAddress]);
  }

  function setUpdatedAddress(updatedAddress) {
    console.log(updatedAddress);
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
            <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Card>
            <CardBody>
              <h2>Мои адреса</h2>
              <div
                style={{
                  width: "100%",
                  height: "1px",
                  background: "rgb(210 210 210)",
                }}
                className={"mb-3"}
              ></div>
              <Row>
                <Col md={12} lg={12}>
                  <div
                    className={
                      "d-flex justify-content-start align-items-center mb-3"
                    }
                  >
                    <Button
                      className={"btn btn-success"}
                      color={"success"}
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
                              {/*<h5 className={"text-muted fs-6"}>*/}
                              {/*  Компания: John Smith LLC*/}
                              {/*</h5>*/}
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
                        <h3 className={"mt-3 text-center fs-18 text-muted"}>
                          Адрес ещё не был добавлен
                        </h3>
                        <div
                          className={
                            "d-flex justify-content-center align-items-center"
                          }
                        >
                          <lord-icon
                            src={"https://cdn.lordicon.com/zzcjjxew.json"}
                            trigger={"loop"}
                            colors={"primary:#121331,secondary:#08a88a"}
                            state={"hover-jump-spin"}
                            style={{ width: "250px", height: "250px" }}
                          ></lord-icon>
                        </div>
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
        setUpdatedAdress={setUpdatedAddress}
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
