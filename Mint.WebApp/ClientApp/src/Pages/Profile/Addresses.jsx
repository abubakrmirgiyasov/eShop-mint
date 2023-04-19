import React, { useCallback, useState } from "react";
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

const Addresses = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isModal, setIsModal] = useState(false);
  const [isDeleteModal, setIsDeleteModal] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [address, setAddress] = useState([]);

  const deleteToggle = useCallback(() => {
    if(isDeleteModal) {
      setIsDeleteModal(false);
    } else {
      setIsDeleteModal(true);
    }
  }, [isDeleteModal]);

  const handleDeleteAddressClick = useCallback((arg) => {
    setAddress({ id: arg.id });
    setIsDeleteModal(true);
    deleteToggle();
  }, [isDeleteModal]);

  const actionToggle = useCallback(() => {
    if (isModal) {
      setIsModal(false);
      setAddress(null);
    } else {
      setIsModal(true);
    }
  }, [isModal]);

  const handleChangeAddressClick = useCallback((arg) => {
    setAddress({
      id: "1234",
      firstName: arg.firstName,
      secondName: arg.secondName,
      email: arg.email,
      phone: arg.phone,
      desc: arg.desc,
    });

    setIsEdit(true);
    actionToggle();
  }, [actionToggle]);

  return (
    <React.Fragment>
      <TabPane tabId={2}>
        <Card className="bg-light">
          <CardBody>
            <Row>
              <Col md={8} lg={9}>
                <div className="d-flex justify-content-start align-items-center mb-3">
                  <h2>Адреса</h2>
                </div>
                <div className="d-flex justify-content-start align-items-center mb-3">
                  <Button 
                    className="btn btn-primary" 
                    color="primary"
                    onClick={() => {
                      setIsEdit(false);
                      actionToggle();
                    }}
                  >
                    <i className="ri-add-line"></i> Добавить новый
                  </Button>
                </div>
                <Row>
                  <Col sm={8}>
                    <Card>
                      <CardBody>
                        <h3>Johnn Smith</h3>
                        <h5 className="text-muted fs-6">
                          Email: admin@myshop.com
                          <br />
                          Phone number: 12345678
                        </h5>
                        <h5 className="text-muted fs-6">John Smith</h5>
                        <h5 className="text-muted fs-6">John Smith LLC</h5>
                        <h5 className="text-muted fs-6">1234 Main Road</h5>
                        <h5 className="text-muted fs-6">New York, AA 12212</h5>
                        <h5 className="text-muted fs-6">UNITED STATES</h5>
                      </CardBody>
                      <CardFooter className="d-flex justify-content-end align-items-center">
                        <Button
                          className="btn btn-success me-3"
                          onClick={() => handleChangeAddressClick({
                            firstName: "test1",
                            secondName: "test2",
                            email: "arg.email",
                            phone: "arg.phone",
                            desc: "arg.desc",
                          })}
                        >
                          <i className="ri-edit-line"></i> Изменить
                        </Button>
                        <Button 
                          className="btn btn-danger"
                          onClick={() => handleDeleteAddressClick({ id: "123", })}
                        >
                          <i className="ri-delete-bin-7-line"></i> Удалить
                        </Button>
                      </CardFooter>
                    </Card>
                  </Col>
                </Row>
              </Col>
            </Row>
          </CardBody>
        </Card>
      </TabPane>
      <AddressesAction 
        isOpen={isModal}
        toggle={actionToggle}
        address={address}
      />
      <DeleteAddress 
        isOpen={isDeleteModal}
        toggle={deleteToggle}
        id={address}
      />
    </React.Fragment>
  );
};

export default Addresses;
