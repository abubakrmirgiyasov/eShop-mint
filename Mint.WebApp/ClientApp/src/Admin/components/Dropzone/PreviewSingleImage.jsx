import React, { useState } from "react";
import Dropzone from "react-dropzone";
import { Link } from "react-router-dom";
import { Card, Col, Row } from "reactstrap";

const PreviewSingleImage = ({ setSelectedImage, image, name }) => {
  const [selectedFiles, setSelectedFiles] = useState([]);
  const [parentImage, setParentImage] = useState(image);

  const handleFileDrop = (files) => {
    files.map((file) =>
      Object.assign(file, {
        preview: URL.createObjectURL(file),
        formattedSize: formatBytes(file.size),
      })
    );
    setSelectedFiles(files);
    setSelectedImage(files);
    setParentImage(null);
  };

  function formatBytes(bytes, decimals = 2) {
    if (bytes === 0) return "0 Bytes";

    const k = 1024;
    const dm = decimals > 0 ? decimals : 0;
    const sizes = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
    const res = Math.floor(Math.log(bytes) / Math.log(k));
    return (
      parseFloat((bytes / Math.pow(k, res)).toFixed(dm)) + " " + sizes[res]
    );
  }

  function getImageSize(image) {
    const img = new Image();
    img.src = image;
    return img.toString().length;
  }

  return (
    <React.Fragment>
      <Dropzone
        onDrop={handleFileDrop}
        accept={{
          "image/jpeg": [],
          "image/png": [],
          "image/svg": [],
          "image/webp": [],
        }}
        multiple={false}
      >
        {({ getRootProps }) => (
          <div className={"dropzone dz-clickable"}>
            <div className={"dz-message needsclick"} {...getRootProps()}>
              <div className={"mb-3"}>
                <i
                  className={"display-4 text-muted ri-upload-cloud-2-fill"}
                ></i>
              </div>
              <h4>Перетащите файлы сюда или нажмите, чтобы загрузить.</h4>
            </div>
          </div>
        )}
      </Dropzone>
      <div className={"list-unstyled mb-0"} id={"file-previews"}>
        {selectedFiles.map((file, index) => {
          return (
            <Card
              className={
                "mt-1 mb-0 shadow-none border dz-processing dz-image-preview dz-success dz-complete"
              }
              key={index + "-file"}
            >
              <div className={"p-2"}>
                <Row className={"align-items-center"}>
                  <Col className={"col-auto"}>
                    <img
                      data-dz-thumbnail={""}
                      height={"80"}
                      className={"avatar-sm rounded bg-light"}
                      alt={file.name}
                      src={file.preview || image}
                    />
                  </Col>
                  <Col>
                    <Link to={"#"} className={"text-muted font-weight-bold"}>
                      {file.name}
                    </Link>
                    <p className="mb-0">
                      <strong>{file.formattedSize}</strong>
                    </p>
                  </Col>
                </Row>
              </div>
            </Card>
          );
        })}
        {parentImage ? (
          <Card
            className={
              "mt-1 mb-0 shadow-none border dz-processing dz-image-preview dz-success dz-complete"
            }
          >
            <div className={"p-2"}>
              <Row className={"align-items-center"}>
                <Col className={"col-auto"}>
                  <img
                    data-dz-thumbnail={""}
                    height={"80"}
                    className={"avatar-sm rounded bg-light"}
                    alt=""
                    src={image}
                  />
                </Col>
                <Col>
                  <Link to="#" className={"text-muted font-weight-bold"}>
                    {name}
                  </Link>
                  <p className="mb-0">
                    <strong>{getImageSize(image)} KB</strong>
                  </p>
                </Col>
              </Row>
            </div>
          </Card>
        ) : null}
      </div>
    </React.Fragment>
  );
};

export default PreviewSingleImage;
