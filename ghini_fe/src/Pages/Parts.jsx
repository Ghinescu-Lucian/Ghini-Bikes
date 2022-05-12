import {Grid} from "@material-ui/core" 
import Content from "../Components/Content";
import Nav from "../Components/Nav";

const Parts = () => {
    return (
        <div>
            <Grid container direction="column">
                <Grid item container>
                    <Grid item xs={false} sm={2}></Grid>
                    <Grid item xs={12} sm={8}>
                        <Content/>
                    </Grid>
                    <Grid item xs={false}sm={2}></Grid>
                </Grid>
            </Grid>
        </div>
    );
};
export default Parts;