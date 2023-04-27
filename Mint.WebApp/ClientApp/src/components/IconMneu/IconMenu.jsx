import React from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import { IconsList } from "../../constants/Common";

const IconMenu = ({ isOpen, toggle, handleSetIconClick, activeIco }) => {
  const setIcon = (item) => {
    handleSetIconClick(item);
    toggle();
  };

  return (
    <React.Fragment>
      <Modal
        isOpen={isOpen}
        toggle={toggle}
        // centered={true}
        // className={"modal-xxl fade zoomIn"}
      >
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          Меню иконок
        </ModalHeader>
        <ModalBody>
          <Row>
            {IconsList.map((item, key) => (
              <Col lg={2} key={key} className={"mb-3"}>
                {activeIco === item}
                <Button
                  color={activeIco === item.label ? "success" : "light"}
                  className={`btn ${
                    activeIco === item.label ? "btn-success" : "btn-light"
                  } w-100 btn-icon fs-16`}
                  onClick={() => setIcon(item.label)}
                >
                  <i className={item.label}></i>
                </Button>
              </Col>
            ))}
          </Row>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default IconMenu;
