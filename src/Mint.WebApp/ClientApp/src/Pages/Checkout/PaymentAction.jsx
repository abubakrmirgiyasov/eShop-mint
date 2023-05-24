import React from "react";
import { Modal, ModalBody, ModalHeader } from "reactstrap";

const PaymentAction = ({ isOpen, toggle, close }) => {
  const handleCloseClick = () => {
    toggle();
    close();
  };

  return (
    <React.Fragment>
      <Modal isOpen={isOpen} centered={true}>
        <ModalHeader toggle={handleCloseClick}>test</ModalHeader>
        <ModalBody>asd</ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default PaymentAction;
