import React, { useState } from "react";
import { Modal, ModalBody, Spinner } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";

const DeleteAddress = (props) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const onDeleteClick = () => {
    setIsLoading(true);

    fetchWrapper
      .delete("api/user/deleteuseraddress/" + props.id)
      .then((response) => {
        setIsLoading(false);
        props.toggle();
        props.setAddressAfterDeleting(props.id);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  };

  return (
    <React.Fragment>
      <Modal isOpen={props.isOpen} toggle={props.toggle} centered={true}>
        {error ? <Error message={error} /> : null}
        <ModalBody className="py-3 px-5">
          <div className="mt-2 text-center">
            <lord-icon
              src="https://cdn.lordicon.com/gsqxdxog.json"
              trigger="loop"
              colors="primary:#f7b84b,secondary:#f06548"
              style={{ width: "100px", height: "100px" }}
            ></lord-icon>
            <div className="mt-4 pt-2 fs-15 mx-4 mx-sm-5">
              <h4>А вы уверены ?</h4>
              <p className="text-muted mx-4 mb-0">
                А вы уверены что хотите удалить эту запись ?
              </p>
            </div>
          </div>
          <div className="d-flex gap-2 justify-content-center mt-4 mb-2">
            <button
              type="button"
              className="btn w-sm btn-light"
              data-bs-dismiss="modal"
              onClick={props.toggle}
            >
              Закрыть
            </button>
            <button
              type="button"
              className="btn w-sm btn-danger "
              id="delete-record"
              onClick={onDeleteClick}
              disabled={isLoading}
            >
              {isLoading ? (
                <Spinner size={"sm"} className="me-2">
                  Loading...
                </Spinner>
              ) : null}
              Удалить
            </button>
          </div>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default DeleteAddress;
