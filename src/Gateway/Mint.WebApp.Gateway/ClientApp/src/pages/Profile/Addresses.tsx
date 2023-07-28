import React, { FC, useCallback, useEffect, useState } from "react";
import { IUserAddress, IUser } from "../../services/types/IUser";
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
import CustomDivider from "../../components/Common/CustomDivider";
import { fetch } from "../../helpers/fetch";
import { Error } from "../../components/Notifications/Error";

interface IAddresses {
  user: IUser;
  activeTab: number;
}

const Addresses: FC<IAddresses> = ({ activeTab, user }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [isEdit, setIsEdit] = useState<boolean>(false);
  const [isActionModal, setIsActionModal] = useState<boolean>(false);
  const [isDeleteModal, setIsDeleteModal] = useState<boolean>(false);
  const [address, setAddress] = useState<IUserAddress>(null);
  const [addresses, setAddresses] = useState<IUserAddress[]>([]);

  useEffect(() => {
    if (activeTab === 2) {
      setIsLoading(true);
      fetch()
        .get("/authentication/getme") // "/user/getuseraddresses/" + user.id
        .then((response: IUserAddress[]) => {
          setAddresses(response);
          setIsLoading(false);
          console.log("response");
        })
        .catch((error) => {
          setError(error);
          setAddresses([]);
          setIsLoading(false);
          console.log("errotr");
        });
    }
  }, [activeTab, user]);

  const onAddNewClick = () => {
    setIsEdit(false);
    addressActionWindowToggle();
  };

  const addressActionWindowToggle = useCallback(() => {
    if (isActionModal) {
      setIsActionModal(false);
      setAddress(null);
    } else {
      setIsActionModal(true);
    }
  }, [isActionModal]);

  const onChangeAddressClick = useCallback(
    (address: IUserAddress) => {
      setAddress(address);
      setIsEdit(true);
      addressActionWindowToggle();
    },
    [addressActionWindowToggle]
  );

  const deleteAddressWindowToggle = useCallback(() => {
    if (isDeleteModal) {
      setIsDeleteModal(false);
    } else {
      setIsDeleteModal(true);
    }
  }, [isDeleteModal]);

  const onDeleteAddressClick = useCallback(
    (address: IUserAddress) => {
      setAddress(address);
      setIsDeleteModal(true);
      deleteAddressWindowToggle();
    },
    [deleteAddressWindowToggle]
  );

  return (
    <React.Fragment>
      {error && <Error message={error} />}
      <TabPane tabId={2}>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <Spinner size={"sm"} color={"success"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Card>
            <CardBody>
              <h2>Мои адреса</h2>
              <CustomDivider />
              <Row>
                <Col md={12} lg={12}>
                  <div
                    className={
                      "d-flex justify-content-start align-items-center mb-3"
                    }
                  >
                    <Button
                      type={"button"}
                      className={"btn btn-success"}
                      color={"success"}
                      onClick={onAddNewClick}
                    >
                      <i className={"ri-add-line"}></i> Добавить новый
                    </Button>
                  </div>
                  <Row>
                    {addresses.length === 0 && (
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
                    {addresses.map((address, key) => (
                      <Col key={key} sm={8} className={"w-50"}>
                        <Card>
                          <CardBody className={"bg-light"}>
                            <h3>{address.fullName}</h3>
                            <h5 className={"text-muted fs-6"}>
                              Email: {address.email}
                              <br />
                              Телефон: {address.phone}
                            </h5>
                            <h5 className={"text-muted fs-6"}>
                              ФИО: {address.fullName}
                            </h5>
                            <h5 className={"text-muted fs-6"}>
                              Адрес: {address.fullAddress}
                            </h5>
                            <h5 className={"text-muted fs-6"}>
                              Город: {address.city} Поч. Индекс:{" "}
                              {address.zipCode}
                            </h5>
                            <h5 className={"text-muted fs-6"}>
                              Страна:{" "}
                              <span className={"fw-semibold"}>
                                {address.country}
                              </span>
                            </h5>
                          </CardBody>
                          <CardFooter
                            className={
                              "d-flex justify-content-end align-items-center bg-light"
                            }
                          >
                            <Button
                              type={"button"}
                              className={"btn btn-success me-3"}
                              onClick={() => onChangeAddressClick(address)}
                            >
                              <i className={"ri-edit-line"}></i> Изменить
                            </Button>
                            <Button
                              className={"btn btn-danger"}
                              onClick={() => onDeleteAddressClick(address)}
                            >
                              <i className={"ri-delete-bin-7-line"}></i> Удалить
                            </Button>
                          </CardFooter>
                        </Card>
                      </Col>
                    ))}
                  </Row>
                </Col>
              </Row>
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default Addresses;
