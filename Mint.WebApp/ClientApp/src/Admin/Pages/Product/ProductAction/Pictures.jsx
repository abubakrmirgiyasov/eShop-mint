import React, { useState } from "react";
import { Col, Row, TabPane } from "reactstrap";
import PreviewMultiImage from "../../../components/Dropzone/PreviewMultiImage";
import { Error } from "../../../../components/Notification/Error";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";

const Pictures = ({ isAdded, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [photos, setPhotos] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();

    setIsLoading(true);

    const formData = new FormData();
    formData.append("productId", dataForUpdate?.id);

    if (photos) {
      formData.append("fileType", "");
    }

    const data = {
      productId: dataForUpdate?.id,
      photos: [],
    };

    fetchWrapper.put("api/product/updatepictures", photos, false);
  };

  return (
    <TabPane tabId={3}>
      {error ? <Error message={error} /> : null}
      {isAdded ? (
        isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <form onSubmit={handleSubmit}>
            <Row>
              <Col lg={12}>
                <PreviewMultiImage />
              </Col>
            </Row>
          </form>
        )
      ) : (
        <div className={"d-flex flex-column align-items-center"}>
          <h3 className={"text-center"}>
            Сначала вам нужно создать товар, чтобы заполнить остальные поля.
          </h3>
          <h5 className={"text-center text-muted fs-14 mt-3"}>
            Вернитесь на вкладку Информация чтобы создать.
          </h5>
        </div>
      )}
    </TabPane>
  );
};

export default Pictures;
