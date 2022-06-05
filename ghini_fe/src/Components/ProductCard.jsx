import React, { useEffect, useState } from "react"
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import DeleteIcon from "@material-ui/icons/Delete";
import SettingsIcon from "@material-ui/icons/Settings";
import { Avatar, IconButton, CardMedia } from "@material-ui/core";
import "./CSS/ProductCard.css";
import { CloseButton } from "./CloseButton";
import * as bikeService from '../Services/BikeService.js';
import * as partService from '../Services/PartService.js';
import * as accessoryService from '../Services/AccessoryService.js';
import { UpdateBikeForm } from "./UpdateBikeForm";


//  
const ProductCard = ({ props, handleClick, image, role, id, data }) => {
  const { manufacturer, model, description, price } = props;
  const [token, setToken] = useState("");

  // console.log("DATATD:",data.category);

  useEffect(() => {
    setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
  }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
  );

  var popupViews = document.querySelectorAll('.popup-viewa');
  var popupBtns = document.querySelectorAll('.popup-btna');
  var closeBtns = document.querySelectorAll('.close-btna');
  var addBtns = document.querySelectorAll('.add-cart-btna');

  //javascript for quick view button
  var popup = function (popupClick) {
    popupViews[popupClick].classList.add('active');
  }

  popupBtns.forEach((popupBtn, i) => {
    popupBtn.addEventListener("click", () => {
      popup(i);
    });
  });
  //javascript for close button
  closeBtns.forEach((closeBtn) => {
    closeBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });

  addBtns.forEach((addBtn) => {
    addBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });

  const deleteProduct = async () => {
    if (data.category <= 3) {
      console.log("AICI");
      try {
        var AddBike_Result = await bikeService.DeleteBike(id, token);
      }
      catch (err) {
        console.log("Something went wrong", err);
        alert("Something went wrong!");
      }
      if (AddBike_Result >= 200 && AddBike_Result < 210) {
        alert("Product deleted with success!")
        window.location.reload(false);
      }

      else alert("Something went wrong!");
    }
    else if (data.category == 4) {
      try {
        var result = await partService.DeletePart(id, token);
      }
      catch (err) {
        console.log("Something went wrong", err);
        alert("Something went wrong!");
      }
      if (result >= 200 && result < 210) {
        alert("Product deleted with success!")
        window.location.reload(false);
      }

      else alert("Something went wrong!");

    }
    else if (data.category == 5) {
      try {
        var result = await accessoryService.DeleteAccessory(id, token);
      }
      catch (err) {
        console.log("Something went wrong", err);
        alert("Something went wrong!");
      }
      if (result >= 200 && result < 210) {
        alert("Product deleted with success!")
        window.location.reload(false);
      }

      else alert("Something went wrong!");

    }
  }


  let description2 = description.split(' ').slice(0, 2).join(' ');
  let descrp = description.split('\n');


  return (
    <div className="product-carda">
      <Card>
        <CardHeader
          avatar={<Avatar src={image} />}
          action={
            role === 'Administrator' ?
              (
                <IconButton aria-label="settings" onClick={deleteProduct} style={{ background: 'rgba(151, 126, 11, 0.205)' }}>
                  <DeleteIcon id="delete" />
                </IconButton>
              ) : (<div></div>)

          }

          title={manufacturer}
          subheader={model}
          style={{ background: 'rgba(178, 179, 168, 0.363)' }}
        />

        <CardMedia style={{ height: "200px", width: "350px" }} image={image} />
        <CardContent>
          <Typography variant="body2" component="p">
            {description2}
          </Typography>
        </CardContent>
        <CardActions>
          {/* <Button size="small">BUY NOW</Button> */}
          {/* <Button size="small">OFFER</Button> */}
          <Button className="popup-btna" style={{ background: '#ffb84d' }} >Details</Button>
        </CardActions>
      </Card>
      <div className="product-carda">
        <div className="producta">
          <div className="popup-viewa" style={{ height: "750px" }}>
            <div className="popup-carda">
              <button className="close-btna" style={{ background: '#ffb84d' }}>&times;</button>
              <div className="product-imga">
                <img style={{ height: "500px", width: "500px" }} src={image} />
              </div>
              <div className="infoa" style={{ height: "500px", width: "500px" }} >
                <h2>{manufacturer}<br /><span>{model}</span></h2>
                <p>{descrp.map((e) => {
                  return (
                    <a> {e}<br></br></a>
                  )
                })}</p>
                <p>{price} RON</p>
                {role === "Administrator" ? (<div></div>) : (<button name="add_to_cart" className="add-cart-btna" onClick={() => handleClick(props)}> Add to cart</button>)}
                {/* </form> */}
                {
                  role === 'Administrator' ? (
                    <div>
                      <Button className="popup-btna" style={{ background: '#ffb84d', color: 'rgba(29, 29, 75, 0.625)', fontWeigh: '900' }}>Edit</Button>
                      {/* <div class="product-card"> */}
                      <div className="producta">
                        <div className="popup-viewa" style={{ height: "1px" }}>
                          <div className="popup-carda">
                            <UpdateBikeForm data={data} />

                          </div>
                        </div>
                      </div>
                    </div>
                  ) : (<div></div>)
                }
              </div>
            </div>

          </div>
        </div>
      </div >
    </div >

  );
};

export default ProductCard;